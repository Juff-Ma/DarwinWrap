using DarwinWrap.Shared;
using DarwinWrap.UI.Forms;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using DarwinWrap.Commands;
using DarwinWrap.Commands.Creation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Color = Spectre.Console.Color;

namespace DarwinWrap;

internal sealed class AppContext : ApplicationContext, IAppController
{
    private readonly NativeWindow? _consoleWindow;
    private readonly IAnsiConsole _console;

    public class MainCommand : Command<MainCommand.Settings>
    {
        public class Settings : GlobalSettings
        {
            [CommandOption("--my-console", IsHidden = true)]
            [DefaultValue(false)]
            public bool MyConsole { get; init; }
        }

        protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
        {
            var ctx = context.Data! as AppContext;
            if (settings.MyConsole)
            {
                Console.Title = ctx!.GetMainAssembly().GetTitle();
                Console.SetWindowSize(80, 40);
                Console.SetBufferSize(1000, 1000);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                ctx.DefaultStyle = Style.Plain
                    .Foreground(Color.Black)
                    .Background(Color.White);
            }
            if (!settings.NoLogo) ctx!.PrintLogo();
            if (settings.Verbose) ctx!.SetVerbose();

            return ctx!.StartGui(settings.MyConsole);
        }
    }

    public int StartGui(bool claimConsole)
    {
        _shouldExitAfterCommand = false;

        var consoleWindow = claimConsole ? _consoleWindow : null;
        if (claimConsole)
        {
            this.IfVerbose(() => _console.WriteLine("Claiming console as own.", DefaultStyle));
        }

        MainForm = new WizardForm(this);
        try
        {
            MainForm.Show(consoleWindow ?? throw new ArgumentNullException());
        }
        catch
        {
            this.IfVerbose(() => _console.WriteLine("Console not claimed.", DefaultStyle));
            MainForm.Show();
        }

        return 0;
    }

    private AppContext(string[] args)
    {
        _console = AnsiConsole.Create(new AnsiConsoleSettings
        {
            ColorSystem = ColorSystemSupport.Detect,
            Ansi = AnsiSupport.Detect,
            Interactive = InteractionSupport.Detect,
            Out = new AnsiConsoleOutput(Console.Out)
        });

        nint consoleHandle = GetConsoleWindow();
        if (consoleHandle != IntPtr.Zero)
        {
            _consoleWindow = new();
            _consoleWindow.AssignHandle(consoleHandle);
        }

        CommandApp<MainCommand> app = new();
            
        app.WithData(this)
           .WithDescription(GetMainAssembly().GetDescription())
           .Configure(c =>
        {
            c.Settings.Console = _console;
            c.Settings.ApplicationName = GetMainAssembly().GetTitle();
            c.Settings.ApplicationVersion = GetMainAssembly().GetInformationalVersion();
            c.Settings.Culture = CultureInfo.InvariantCulture;

            c.AddCommand<BuildCommand>("build")
                .WithAlias("b")
                .WithDescription("Builds an MSI file from an existing DarwinWrap manifest.")
                .WithData(AsController())
                .WithExample("build MyApp.dwm -i MySetup.exe".Split(' '))
                .WithExample("build MyCert.dwm --nologo -i Cert.crt -o MyCert.msi".Split(' '))
                .WithExample(("b MyComplexApp.dwm --verbose -i MyComplexSetup.exe " +
                              "-a ExtraFiles\\ -o MyCool.msi").Split(' '));

            c.AddBranch("create", b =>
            {
                b.SetDescription("Create a new manifest.");

                b.AddCommand<DirectoryCommand>("directory")
                    .WithAlias("dir")
                    .WithAlias("d")
                    .WithDescription("Create a directory/ZIP based MSI")
                    .WithData(AsController())
                    .WithExample("create", "directory", "-i", "MyFiles\\", "--name", "\"Hello World\"")
                    .WithExample("create dir -v -a MyFiles\\ -b --admin-install --shortcut-file-name app.exe"
                        .Split(' '));

                b.AddCommand<SetupCommand>("setup")
                    .WithAlias("s")
                    .WithAlias("exe")
                    .WithAlias("e")
                    .WithDescription("Create a setup.exe based MSI")
                    .WithData(AsController())
                    .WithExample("create setup -i MySetup.exe --id MyApp --arch arm64".Split(' '))
                    .WithExample(("c exe -i Setup.exe -a ExtraFiles\\ --icon MyIcon.ico " +
                                  "--file-grab-visible-name --file-grab-publisher --file-grab-version").Split(' '))
                    .WithExample(("c s -i AppSetup.exe -b -v --setup-arguments /S --setup-registry-name app " +
                                  "--admin-install --signing-cert Cert.pfx --signing-password VerySecurePassword " +
                                  "--reg-grab-visible-name --reg-grab-description --hide-programs-entry").Split(' '));

                b.AddCommand<PackageCommand>("package")
                    .WithAlias("pack")
                    .WithAlias("p")
                    .WithAlias("msixbundle")
                    .WithAlias("msix")
                    .WithAlias("m")
                    .WithAlias("appxbundle")
                    .WithAlias("appx")
                    .WithAlias("a")
                    .WithDescription("Create an APPX/MSIX (or bundle) based MSI.")
                    .WithData(AsController())
                    .WithExample(("create package -i MyPackage.appx --package-full-name My.App_1.0.0.0_x64 " +
                                  "--package-grab-family-name").Split(' '))
                    .WithExample(("create msix -i MyBundle.msixbundle -o Bundle.msi --license GPL.rtf " +
                                  "--package-grab-full-name --package-grab-family-name --package-grab-id " +
                                  "--package-grab-visible-name --package-grab-publisher --package-grab-version")
                        .Split(' '));

                b.AddCommand<ScriptCommand>("script")
                    .WithAlias("s")
                    .WithAlias("batch")
                    .WithAlias("bat")
                    .WithAlias("b")
                    .WithDescription("Create a batch script based MSI.")
                    .WithData(AsController())
                    .WithExample("create script -i Files\\ --install-script-name install.bat".Split(' '))
                    .WithExample(("create bat -i Files\\ -v -b --basic-ui --arch x86 " +
                                  "--install-script-name install.bat --uninstall-script-name uninstall.bat " +
                                  "--update-script-name update.bat --run-install-before-update").Split(' '));

                b.AddCommand<RegistryCommand>("registry")
                    .WithAlias("reg")
                    .WithAlias("r")
                    .WithDescription("Create a registry based MSI.")
                    .WithData(AsController())
                    .WithExample("create reg --id da041329-4886-45c0-84e1-70a79a751a77 -i MyData.reg".Split(' '));

                b.AddCommand<CertificateCommand>("certificate")
                    .WithAlias("cert")
                    .WithAlias("c")
                    .WithDescription("Create a certificate based MSI.")
                    .WithData(AsController())
                    .WithExample("create cert -i CA.crt --admin-install --cert-store-name Root".Split(' '));

            }).WithAlias("c");

#if DEBUG
            c.PropagateExceptions();
            c.ValidateExamples();
#endif
        });

        Environment.ExitCode = app.Run(args);
        if (_shouldExitAfterCommand) throw new PleaseExitException();
    }

    // This is such a massive hack, but it works so eh
#pragma warning disable RCS1194
    private class PleaseExitException : Exception;
#pragma warning restore RCS1194

    /// <summary>
    /// This gets the current console window handle
    /// </summary>
    [DllImport("kernel32.dll")]
    private static extern nint GetConsoleWindow();

    public IAppController AsController() => this;

    public static void StartApp(string[] args)
    {
        Application.EnableVisualStyles();
        try
        {
            Application.Run(new AppContext(args));
        }
        catch (PleaseExitException)
        {
            // Normal exit, do nothing
        }
    }

    public void ExitImmediately()
    {
        Application.Exit();
    }

    private bool _shouldExitAfterCommand = true;

    public Assembly GetMainAssembly()
    {
        return Assembly.GetExecutingAssembly();
    }

    public Style DefaultStyle { get; set; } = Style.Plain;

    public bool BeVerbose { get; private set; }

    public IAnsiConsole GetConsole()
    {
        return _console;
    }

    public void PrintLogo()
    {
        const string logoTop =
            """
             _____                      _   __          __              
            |  __ \                    (_)  \ \        / /              
            | |  | | __ _ _ ____      ___ _ _\ \  /\  / / __ __ _ _ __  
            | |  | |/ _` | '__\ \ /\ / / | '_ \ \/  \/ / '__/ _` | '_ \ 
            | |__| | (_| | |   \ V  V /| | | | \  /\  /| | | (_| | |_) |
            |_____/ \__,_|_|    \_/\_/ |_|_| |_|\/  \/ |_|  \__,_| .__/ 
                                                               | |    
            """;
        const string logoBottom =
            """
            |_|      
            """;
        var logoStyle = DefaultStyle.Foreground(Color.LightSkyBlue3_1);
        _console.WriteLine(logoTop, logoStyle);
        var copyright = GetMainAssembly().GetCopyright();
        _console.Write($"{copyright,-51}", DefaultStyle.Foreground(Color.CadetBlue).Decoration(Decoration.Bold));
        _console.WriteLine(logoBottom, logoStyle);

        var description = GetMainAssembly().GetDescription();
        _console.WriteLine($"{description}\n", logoStyle);
    }

    public void SetVerbose()
    {
        BeVerbose = true;
    }
}

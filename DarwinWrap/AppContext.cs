using DarwinWrap.Shared;
using DarwinWrap.UI.Forms;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using DarwinWrap.Commands;
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

            c.AddCommand<BuildCommand>("build")
                .WithAlias("b")
                .WithDescription("Builds an MSI file from an existing DarwinWrap manifest.");
        });

        app.Run(args);
    }

    /// <summary>
    /// This gets the current console window handle
    /// </summary>
    [DllImport("kernel32.dll")]
    private static extern nint GetConsoleWindow();

    public void ExitApp()
    {
        Application.Exit();
    }

    public static int StartApp(string[] args)
    {
        Application.EnableVisualStyles();
        Application.Run(new AppContext(args));
        return 0;
    }

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

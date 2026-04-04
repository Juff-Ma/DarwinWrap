using System.Reflection;
using System.Runtime.InteropServices;
using DarwinWrap.Shared;
using DarwinWrap.UI.Forms;

namespace DarwinWrap;

internal sealed class AppContext : ApplicationContext, IAppController
{
    private readonly NativeWindow? _consoleWindow;

    private AppContext(string[] args)
    {
        nint consoleHandle = GetConsoleWindow();
        if (consoleHandle != IntPtr.Zero)
        {
            _consoleWindow = new();
            _consoleWindow.AssignHandle(consoleHandle);
        }

        //TODO: process args
        //TODO: literally everything
        MainForm = new WizardForm(this);
        if (_consoleWindow is not null)
        {
            MainForm.Show(_consoleWindow);
            return;
        }
        MainForm.Show();
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
}

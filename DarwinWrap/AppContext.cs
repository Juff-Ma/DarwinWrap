using System.Runtime.InteropServices;
using DarwinWrap.UI.Forms;

namespace DarwinWrap;

internal sealed class AppContext : ApplicationContext
{
    private readonly NativeWindow? _consoleWindow;

    public AppContext(string[] args)
    {
        nint consoleHandle = GetConsoleWindow();
        if (consoleHandle != IntPtr.Zero)
        {
            _consoleWindow = new();
            _consoleWindow.AssignHandle(consoleHandle);
        }

        //TODO: process args
        //TODO: literally everything
        MainForm = new WizardForm();
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
}

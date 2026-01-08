using System.Runtime.InteropServices;

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
        //TODO: show actual main window
        //TODO: literally everything
        Form mainForm = new();
        if (_consoleWindow is not null)
        {
            mainForm.Show(_consoleWindow); 
            return;
        }
        
        mainForm.Show();
    }

    /// <summary>
    /// This gets the current console window handle
    /// </summary>
    [DllImport("kernel32.dll")]
    private static extern nint GetConsoleWindow();
}

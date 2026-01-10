namespace DarwinWrap;

internal static class Entrypoint
{
    [STAThread]
    private static void Main(string[] args)
    {
        Environment.ExitCode = AppContext.StartApp(args);
    }
}

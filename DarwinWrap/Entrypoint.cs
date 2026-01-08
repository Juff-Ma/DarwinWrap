namespace DarwinWrap;

internal static class Entrypoint
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.Run(new AppContext(args));
    }
}

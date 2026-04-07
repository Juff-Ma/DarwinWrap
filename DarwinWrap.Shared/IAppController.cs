using System.Reflection;
using Spectre.Console;

namespace DarwinWrap.Shared;

public interface IAppController
{
    public void ExitApp();

    public Assembly GetMainAssembly();

    public IAnsiConsole GetConsole();
    public void PrintLogo();

    public void SetVerbose();
    public bool BeVerbose { get; }
}

public static class AppControllerExtensions
{
    public static void IfVerbose(this IAppController controller, Action action)
    {
        if (controller.BeVerbose)
        {
            action.Invoke();
        }
    }
}
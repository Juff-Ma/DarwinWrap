using System.Reflection;
using Spectre.Console;

namespace DarwinWrap.Shared;

public interface IAppController
{
    public void ExitApp();

    public Assembly GetMainAssembly();

    public IAnsiConsole GetConsole();
    public void PrintLogo();
}

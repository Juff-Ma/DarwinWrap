using System.Reflection;

namespace DarwinWrap.Shared;

public interface IAppController
{
    public void ExitApp();

    public Assembly GetMainAssembly();
}

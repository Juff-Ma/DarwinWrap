using DarwinWrap.Shared.Settings;

namespace DarwinWrap.Shared;

public enum PackageType
{
    Directory,
    Setup,
    Package,
    Script,
    Registry,
    Certificate
}

public static class PackageExtensions
{
    extension(IGenericPackageSettings package)
    {
        public PackageType Type
        {
            get
            {
                return package switch
                {
                    IDirectoryPackageSettings => PackageType.Directory,
                    ISetupPackageSettings => PackageType.Setup,
                    IAppxPackageSettings => PackageType.Package,
                    IScriptPackageSettings => PackageType.Script,
                    IRegistryPackageSettings => PackageType.Registry,
                    ICertificatePackageSettings => PackageType.Certificate,
                    _ => throw new ArgumentException("Settings is not a valid package", nameof(package))
                };
            }
        }
    }
}

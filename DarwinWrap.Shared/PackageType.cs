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

// TODO: convert this to an extension block
//       This is blocked by VS2022 having a heart attack when trying to use extension blocks
//       It technically works but VS just throws errors around which is unfortunate
//       Should I upgrade to VS2026 at some point this will be an easy update
public static class PackageExtensions
{
    /// <summary>
    /// This gets the type for the package settings.
    /// It is used to determine which type of package is being used and to cast the settings to the correct type.
    /// </summary>
    /// <param name="package">The package settings instance.</param>
    /// <returns>The type of the package.</returns>
    /// <exception cref="ArgumentException">If the settings object does not correspond to a valid package type.</exception>
    public static PackageType GetType(this IGenericPackageSettings package)
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

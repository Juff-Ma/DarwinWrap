namespace DarwinWrap.Shared.Settings;

// Also for MSIX and bundles
public interface IAppxPackageSettings : ISignableSettings
{
    /// <summary>
    /// Path to the MSIX, APPX, etc. file to be included in the package.
    /// </summary>
    string PackageFile { get; set; }
    string? PackageFullName { get; set; }
    string? PackageFamilyName { get; set; }

    // Can only be read from the package
    bool PackageGrabFullName { get; set; }
    // Either read from package or derived from the full name
    bool PackageGrabFamilyName { get; set; }
    // This could be derived from the full name
    bool PackageGrabId { get; set; }
    // Either grab DisplayName from the package or derive it from the full name or Id
    // Bundles don't have a DisplayName but we can get it from the child packages
    bool PackageGrabName { get; set; }
    // Either DisplayPublisher or Publisher from the package
    // For DisplayPublisher we can also try to grab it from the child packages if it's a bundle
    // Publisher has a technical format so we should avoid it at all costs
    bool PackageGrabPublisher { get; set; }
    // Either grab from package or derive it from the full name
    bool PackageGrabVersion { get; set; }
    // Either grab from package or derive it from the full name
    bool PackageGrabArch { get; set; }

    /// <summary>
    /// Whether to allow unsigned packages.
    /// </summary>
    bool AllowUnsignedPackage { get; set; }
}

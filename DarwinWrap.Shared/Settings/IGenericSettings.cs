namespace DarwinWrap.Shared.Settings;

public interface IGenericSettings
{
    /// <summary>
    /// The ID of the Msi package.
    /// If <see langword="null"/> or empty should be generated.
    /// If it is a GUID, it should be used as is.
    /// If not, then generate a new GUID based on the string value.
    /// </summary>
    string? Id { get; set; }

    /// <summary>
    /// User facing name of the package. If <see langword="null"/> or empty should be generated based on the Id.
    /// </summary>
    string? VisibleName { get; set; }

    /// <summary>
    /// Version of the package. Default of 1.0
    /// </summary>
    string? Version { get; set; }

    /// <summary>
    /// Package architecture.
    /// </summary>
    Architecture? Architecture { get; set; }

    /// <summary>
    /// Whether the installation is machine wide.
    /// </summary>
    bool? AdminInstall { get; set; }

    /// <summary>
    /// Whether to use the basic UI or the default one.
    /// </summary>
    bool? BasicUi { get; set; }

    /// <summary>
    /// Description of the package.
    /// </summary>
    string? AppDescription { get; set; }

    /// <summary>
    /// The name of the publisher. This is used in the Add/Remove Programs.
    /// </summary>
    string? Publisher { get; set; }

    /// <summary>
    /// Path to the license file.
    /// If this ends in .rtf it will be used as is, otherwise it will be converted to RTF format on build.
    /// </summary>
    string? LicensePath { get; set; }

    /// <summary>
    /// Path to the banner image.
    /// Must be 493x58 pixels.
    /// </summary>
    string? BannerImagePath { get; set; }

    /// <summary>
    /// Path to the banner image.
    /// Must be 493x312 pixels.
    /// </summary>
    string? DialogImagePath { get; set; }

    /// <summary>
    /// Path to the app ico file.
    /// </summary>
    string? IconPath { get; set; }

    /// <summary>
    /// About URL for the app
    /// </summary>
    string? AboutUrl { get; set; }

    /// <summary>
    /// Don't show change button
    /// </summary>
    bool? ForbidChange { get; set; }

    /// <summary>
    /// Don't show repair button
    /// </summary>
    bool? ForbidRepair { get; set; }

    /// <summary>
    /// Don't show uninstall button
    /// </summary>
    bool? ForbidUninstall { get; set; }

    /// <summary>
    /// Hide the program entry in the Start Menu and Add/Remove Programs.
    /// </summary>
    bool? HideProgramEntry { get; set; }
}
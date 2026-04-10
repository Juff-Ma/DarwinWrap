using System.ComponentModel;
using DarwinWrap.Shared;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class CreationSettings : SubcommandSettings, ISignableSettings
{
    [CommandOption("-b|--build")]
    [Description("Whether to build the project without creating the manifest.")]
    [DefaultValue(false)]
    public bool BuildAfterCreate { get; init; }

    [CommandOption("--id")]
    [Description("The application ID. If not specified, one will be generated.")]
    [DefaultValue(null)]
    public string? Id { get; set; }
    [CommandOption("--name")]
    [Description("The visible name of the application. If not specified, it will be generated based on the ID.")]
    [DefaultValue(null)]
    public string? VisibleName { get; set; }
    [CommandOption("--version")]
    [Description("The application version. If not specified, it will be set to 1.0.")]
    [DefaultValue(null)]
    public string? Version { get; set; }
    [CommandOption("--arch")]
    [Description("The target architecture. Default is x64.")]
    [DefaultValue(Architecture.X64)]
    public Architecture Architecture { get; set; } = Architecture.X64;
    [CommandOption("--admin-install")]
    [Description("Whether the application will be installed for all users.")]
    [DefaultValue(false)]
    public bool AdminInstall { get; set; }
    [CommandOption("--basic-ui")]
    [Description("Use a simplified UI without user interaction.")]
    [DefaultValue(false)]
    public bool BasicUi { get; set; }
    [CommandOption("--description")]
    [Description("The application description. If not specified, it will be left empty.")]
    [DefaultValue(null)]
    public string? AppDescription { get; set; }
    [CommandOption("--publisher")]
    [Description("The name of the publisher. The ID will be used if left empty.")]
    [DefaultValue(null)]
    public string? Publisher { get; set; }
    [CommandOption("--license")]
    [Description("Path to the license file. If this ends in .rtf it will be used as is, otherwise it will be converted to RTF format on build.")]
    [DefaultValue(null)]
    public string? LicensePath { get; set; }
    [CommandOption("--banner-image")]
    [Description("Path to the banner image. Must be 493x58 pixels.")]
    [DefaultValue(null)]
    public string? BannerImagePath { get; set; }
    [CommandOption("--dialog-image")]
    [Description("Path to the dialog image. Must be 493x312 pixels.")]
    [DefaultValue(null)]
    public string? DialogImagePath { get; set; }
    [CommandOption("--icon")]
    [Description("Path to the icon file. Must be an .ico file.")]
    [DefaultValue(null)]
    public string? IconPath { get; set; }
    [CommandOption("--about-url")]
    [Description("URL to the about page of the app.")]
    [DefaultValue(null)]
    public string? AboutUrl { get; set; }
    [CommandOption("--forbid-repair")]
    [Description("Don't show repair button.")]
    [DefaultValue(false)]
    public bool ForbidRepair { get; set; }
    [CommandOption("--forbid-uninstall")]
    [Description("Don't show uninstall button.")]
    [DefaultValue(false)]
    public bool ForbidUninstall { get; set; }
    [CommandOption("--system-component")]
    [Description("Mark the application as a system component, this hides the program entry.")]
    [DefaultValue(false)]
    public bool HideProgramEntry { get; set; }

    [CommandOption("--signing-cert")]
    [Description("The certificate to sign the application with. This can be a thumbprint, a file path or a subject name depending on the cert store type.")]
    [DefaultValue(null)]
    public string? SignCert { get; set; }

    [CommandOption("--signing-password")]
    [Description("The password for the signing certificate, if applicable.")]
    [DefaultValue(null)]
    public string? Password { get; set; }

    [CommandOption("--signing-time-url")]
    [Description("A URL to a timestamping server to use when signing.")]
    [DefaultValue(null)]
    public string? TimeUrl { get; set; }
    [CommandOption("--signing-cert-store")]
    [Description("The type of certificate store to use when looking for the signing certificate.")]
    [DefaultValue(null)]
    public CertStoreType? CertStoreType { get; set; }
    [CommandOption("--signing-algorithm")]
    [Description("The algorithm to use for signing.")]
    [DefaultValue(null)]
    public CodeSignAlgorithm? CodeSignAlgorithm { get; set; }
    [CommandOption("--sign-embedded-files")]
    [Description("Whether to sign embedded files as well.")]
    [DefaultValue(false)]
    public bool SignEmbeddedFiles { get; set; }
    [CommandOption("--signtool-location")]
    [Description("Directory where signtool.exe is located.")]
    [DefaultValue(null)]
    public string? SignToolLocation { get; set; }
    [CommandOption("--signing-extra-args")]
    [Description("Additional arguments to pass to signtool.")]
    [DefaultValue(null)]
    public string? CodeSignExtraArguments { get; set; }
}

using System.ComponentModel;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class PackageCommand : Command<PackageCommand.Settings>
{
    public class Settings : CreationSettings, IAppxPackageSettings
    {
        public string PackageFile
        {
            get => PrimaryInput ??
                   throw new ArgumentNullException(nameof(PrimaryInput), "Package file is required.");
            set => PrimaryInput = value;
        }

        [CommandOption("--package-full-name")]
        [Description("The full qualifying name of th package.")]
        [DefaultValue(null)]
        public string? PackageFullName { get; set; }
        [CommandOption("--package-family-name")]
        [Description("The family name of the package.")]
        [DefaultValue(null)]
        public string? PackageFamilyName { get; set; }

        [CommandOption("--package-grab-full-name")]
        [Description("Whether to grab the full name from the package. This will override the specified full name if set.")]
        [DefaultValue(false)]
        public bool PackageGrabFullName { get; set; }
        [CommandOption("--package-grab-family-name")]
        [Description("Whether to grab the family name from the package or the full name.")]
        [DefaultValue(false)]
        public bool PackageGrabFamilyName { get; set; }
        [CommandOption("--package-grab-id")]
        [Description("Whether to derive the id from the full name.")]
        [DefaultValue(false)]
        public bool PackageGrabId { get; set; }
        [CommandOption("--package-grab-visible-name")]
        [Description("Whether to grab the visible name from the package/derive it from the full name.")]
        [DefaultValue(false)]
        public bool PackageGrabName { get; set; }
        [CommandOption("--package-grab-publisher")]
        [Description("Whether to grab the publisher from the package/derive it from the full name.")]
        [DefaultValue(false)]
        public bool PackageGrabPublisher { get; set; }
        [CommandOption("--package-grab-version")]
        [Description("Whether to grab the version from the package/derive it from the full name.")]
        [DefaultValue(false)]
        public bool PackageGrabVersion { get; set; }
        [CommandOption("--package-grab-arch")]
        [Description("Whether to grab the architecture from the package/derive it from the full name. This does not work well for bundles.")]
        [DefaultValue(false)]
        public bool PackageGrabArch { get; set; }
        [CommandOption("--allow-unsigned-package")]
        [Description("Whether to allow unsigned packages. If you don't know whether your package is unsigned or what that means, don't use this.")]
        [DefaultValue(false)]
        public bool AllowUnsignedPackage { get; set; }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

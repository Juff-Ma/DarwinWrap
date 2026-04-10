using System.ComponentModel;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class SetupCommand : Command<SetupCommand.Settings>
{
    public class Settings : FileGrabbableSettings, ISetupPackageSettings
    {
        public string? FilesPath
        {
            get => AuxiliaryInput;
            set => AuxiliaryInput = value;
        }

        public string SetupFile
        {
            get => PrimaryInput ??
                   throw new ArgumentNullException(nameof(PrimaryInput), "Setup file must be specified.");
            set => PrimaryInput = value;
        }

        [CommandOption("--setup-arguments")]
        [Description("Arguments to pass to the setup file when running it.")]
        [DefaultValue(null)]
        public string? SetupArguments { get; set; }
        [CommandOption("--setup-uninstall-arguments")]
        [Description("Arguments to pass to the uninstaller file when uninstalling.")]
        [DefaultValue(null)]
        public string? UninstallArguments { get; set; }

        [CommandOption("--setup-registry-name")]
        [Description("The name of the registry key corresponding to the setup.")]
        [DefaultValue(null)]
        public string? RegistryName { get; set; }
        [CommandOption("--setup-registry-location")]
        [Description("The location of the registry key corresponding to the setup.")]
        [DefaultValue(null)]
        public RegistryLocation? RegistryLocation { get; set; }
        [CommandOption("--reg-grab-id")]
        [Description("Whether to grab the id from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabId { get; set; }
        [CommandOption("--reg-grab-visible-name")]
        [Description("Whether to grab the visible name from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabVisibleName { get; set; }
        [CommandOption("--reg-grab-description")]
        [Description("Whether to grab the description from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabDescription { get; set; }
        [CommandOption("--reg-grab-publisher")]
        [Description("Whether to grab the publisher from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabPublisher { get; set; }
        [CommandOption("--reg-grab-version")]
        [Description("Whether to grab the version from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabVersion { get; set; }
        [CommandOption("--reg-grab-architecture")]
        [Description("Whether to grab the architecture from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabArchitecture { get; set; }
        [CommandOption("--reg-grab-url")]
        [Description("Whether to grab the about URL from the registry.")]
        [DefaultValue(false)]
        public bool RegGrabAboutUrl { get; set; }

        [CommandOption("--hide-programs-entry")]
        [Description("Hide the setup's entry in the programs list. Requires the registry key name.")]
        [DefaultValue(false)]
        public bool HideSetupEntry { get; set; }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

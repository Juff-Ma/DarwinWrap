using System.ComponentModel;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class ScriptCommand : Command<ScriptCommand.Settings>
{
    public class Settings : CreationSettings, IScriptPackageSettings
    {
        public string? FilesPath
        {
            get => PrimaryInput ?? AuxiliaryInput;
            set => PrimaryInput = AuxiliaryInput = value;
        }

        [CommandOption("--install-script-name")]
        [Description("The name of the install script file. If not specified, it will be guessed.")]
        [DefaultValue(null)]
        public string? InstallScriptFile { get; set; }
        [CommandOption("--uninstall-script-name")]
        [Description("The name of the uninstall script file.")]
        [DefaultValue(null)]
        public string? UninstallScriptFile { get; set; }
        [CommandOption("--update-script-name")]
        [Description("The name of the update script file.")]
        [DefaultValue(null)]
        public string? UpdateScriptFile { get; set; }

        [CommandOption("--run-install-before-update")]
        [Description("Whether to run the install script before the update script. " +
                     "If false, only the update script will run on update. " +
                     "If there is no update script, nothing will run unless this is true.")]
        [DefaultValue(false)]
        public bool RunInstallBeforeUpdate { get; set; }
        [CommandOption("--run-uninstall-before-update")]
        [Description("Whether to run the uninstall script before initiating an update.")]
        [DefaultValue(false)]
        public bool RunUninstallBeforeUpdate { get; set; }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

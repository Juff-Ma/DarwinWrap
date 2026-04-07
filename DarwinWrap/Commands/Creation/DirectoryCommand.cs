using System.ComponentModel;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class DirectoryCommand : Command<DirectoryCommand.Settings>
{
    public class Settings : FileGrabbableSettings, IDirectoryPackageSettings
    {
        [CommandOption("--shortcut-file-name")]
        [Description("The file name of the shortcut to create. If not specified, no shortcut will be created.")]
        [DefaultValue(null)]
        public string? ShortcutFileName { get; set; }
        [CommandOption("--shortcut-name")]
        [Description("The visible name of the shortcut. By default equals the file name.")]
        [DefaultValue(null)]
        public string? ShortcutName { get; set; }

        public string? FilesPath {
            get => PrimaryInput ?? AuxiliaryInput;
            set => PrimaryInput = AuxiliaryInput = value;
        }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

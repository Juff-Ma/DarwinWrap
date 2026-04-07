using System.ComponentModel;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands;

internal class BuildCommand : Command<BuildCommand.Settings>
{
    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public class Settings : SubcommandSettings
    {
        [CommandArgument(0, "<manifest>")]
        [Description("Path to the manifest (.dwm) file to build from.")]
        public required string SourceManifest { get; init; }
    }
}

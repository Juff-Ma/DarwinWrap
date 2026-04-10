using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class RegistryCommand : Command<RegistryCommand.Settings>
{
    public class Settings : CreationSettings, IRegistryPackageSettings
    {
        public string RegistryFile
        {
            get => PrimaryInput ??
                   throw new ArgumentNullException(nameof(PrimaryInput), "Registry file is required.");
            set => PrimaryInput = value;
        }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

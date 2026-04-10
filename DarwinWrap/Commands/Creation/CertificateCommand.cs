using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class CertificateCommand : Command<CertificateCommand.Settings>
{
    public class Settings : CreationSettings, ICertificatePackageSettings
    {
        public string CertFile
        {
            get => PrimaryInput ??
                   throw new ArgumentNullException(nameof(CertFile), "Cert file is required.");
            set => PrimaryInput = value;
        }

        [CommandOption("--cert-store-name")]
        [Description("The certificate store to use. Defaults to 'My'.")]
        [DefaultValue(StoreName.My)]
        public StoreName StoreName { get; set; } = StoreName.My;
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

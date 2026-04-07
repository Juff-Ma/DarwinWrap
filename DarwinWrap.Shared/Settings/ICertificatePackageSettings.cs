using System.Security.Cryptography.X509Certificates;

namespace DarwinWrap.Shared.Settings;

// For now only public certs. Since private ones require a password
// Those wouldn't make sense to be distributed via MSI
public interface ICertificatePackageSettings : ISignableSettings
{
    /// <summary>
    /// This should support both DER and PEM formats.
    /// </summary>
    string? CertFile { get; set; }

    StoreName? StoreName { get; set; }
}

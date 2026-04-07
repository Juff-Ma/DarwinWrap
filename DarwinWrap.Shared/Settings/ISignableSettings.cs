namespace DarwinWrap.Shared.Settings;

public interface ISignableSettings : IGenericSettings
{
    /// <summary>
    /// The name of the code signing certificate to use.
    /// This can be the path to a PFX file or the name of a certificate in the Windows Certificate Store.
    /// </summary>
    string? SignCert { get; set; }

    /// <summary>
    /// Gets or sets the URL used to retrieve the current time from an external source.
    /// </summary>
    string? TimeUrl { get; set; }

    /// <summary>
    /// Type of certificate used.
    /// </summary>
    CertStoreType? CertStoreType { get; set; }

    /// <summary>
    /// Code Signing Algorithm to use.
    /// </summary>
    CodeSignAlgorithm? CodeSignAlgorithm { get; set; }

    /// <summary>
    /// Whether to sign all embedded files.
    /// Mostly useful for folder type since everything else this could lead to weird results.
    /// </summary>
    bool SignEmbeddedFiles { get; set; }

    /// <summary>
    /// Folder where signtool.exe is located. If not set, it will be looked for in the system PATH.
    /// </summary>
    string? SignToolLocation { get; set; }

    /// <summary>
    /// Extra arguments to pass to signtool.exe.
    /// </summary>
    string? CodeSignExtraArguments { get; set; }
}

public enum CertStoreType
{
    PfxFile,
    StoreByName,
    StoreBySha1
}

public enum CodeSignAlgorithm
{
    Sha1,
    Sha256
}

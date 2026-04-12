using DarwinWrap.Shared.Settings;

namespace DarwinWrap.Shared;

public interface IManifestFactory
{
    void BuildManifest(IGenericPackageSettings settings, string path);
    PackageType FromManifest(string path, out IGenericPackageSettings settings);
}

using DarwinWrap.Shared;
using DarwinWrap.Shared.Settings;

namespace DarwinWrap.Manifest;

internal class ManifestFactory : IManifestFactory
{
    public void BuildManifest(IGenericPackageSettings settings, string path)
    {
        throw new NotImplementedException();
    }

    public PackageType FromManifest(string path, out IGenericPackageSettings settings)
    {
        throw new NotImplementedException();
    }
}

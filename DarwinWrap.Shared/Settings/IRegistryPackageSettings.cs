namespace DarwinWrap.Shared.Settings;

public interface IRegistryPackageSettings : ISignableSettings
{
    string? RegistryFile { get; set; }
}

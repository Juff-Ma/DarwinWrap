namespace DarwinWrap.Shared.Settings;

public interface ISetupPackageSettings :
    ICanGrabInfosFromFileSettings,
    ISignableSettings,
    IContainFilesSettings
{
    string? SetupFile { get; set; }
    string? SetupArguments { get; set; }
    string? UninstallArguments { get; set; }

    /// <summary>
    /// The name of the registry key to grab infos from. If <see langword="null"/> or empty, no registry key will be used.
    /// This is also required for automatic uninstallation to work.
    /// </summary>
    string? RegistryName { get; set; }
    RegistryLocation? RegistryLocation { get; set; }

    // This can be pretty much everything but often it's just a GUID so perfect
    // If it's not then we have logic for conversion anyway
    bool? RegGrabId { get; set; }
    bool? RegGrabVisibleName { get; set; }
    // This is almost always empty in the registry
    bool? RegGrabDescription { get; set; }
    bool? RegGrabPublisher { get; set; }
    // Registry MOSTLY has valid versions but not always,
    // should sanity check it before using it.
    // There's also the "Version" attribute instead of the "DisplayVersion"
    // but since it contains less Metadata we should prefer the "DisplayVersion" one if present and sane.
    bool? RegGrabVersion { get; set; }
    // Not really possible to grab architecture from registry,
    // but we can try to guess it based on the presence of Wow6432Node in the path.
    bool? RegGrabArchitecture { get; set; }
    // The registry can contain more URLs than just about
    // We can try to grab the about URL if present and fall back to others (e.g. Help)
    bool? RegGrabAboutUrl { get; set; }

    // This hides the Program entry of the setup by setting the registry key "SystemComponent" to 1,
    // which makes it hidden in the Add/Remove Programs list.
    bool? HideSetupEntry { get; set; }
}

public enum RegistryLocation
{
    // Current user in Wow6432 node
    User32,
    // Current user
    User,
    // Current machine in Wow6432 node
    Machine32,
    // Current machine
    Machine
}
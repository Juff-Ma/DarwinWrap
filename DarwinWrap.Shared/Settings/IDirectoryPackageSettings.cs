namespace DarwinWrap.Shared.Settings;

public interface IDirectoryPackageSettings :
    ICanGrabInfosFromFileSettings,
    ISignableSettings,
    IContainFilesSettings
{
    /// <summary>
    /// File for which to create a shortcut or <see langword="null"/> to not create a shortcut.
    /// </summary>
    string? ShortcutFileName { get; set; }

    /// <summary>
    /// Name of the created shortcut. If <see langword="null"/> or empty, the name of the file will be used.
    /// </summary>
    string? ShortcutName { get; set; }
}
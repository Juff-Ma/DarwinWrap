namespace DarwinWrap.Shared.Settings;

public interface ICanGrabInfosFromFileSettings : IGenericSettings
{
    /// <summary>
    /// Path to the file to grab infos from.
    /// If this is a directory, all files in the directory will be included.
    /// If this is a zip file, all files in the zip will be included.
    /// </summary>
    string? InfosFilePath { get; set; }

    bool FileGrabVisibleName { get; set; }
    bool FileGrabDescription { get; set; }
    bool FileGrabPublisher { get; set; }
    bool FileGrabVersion { get; set; }
    bool FileGrabArchitecture { get; set; }
    bool FileGrabIcon { get; set; }
}

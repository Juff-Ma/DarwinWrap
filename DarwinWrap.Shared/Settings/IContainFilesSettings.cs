namespace DarwinWrap.Shared.Settings;

public interface IContainFilesSettings
{
    /// <summary>
    /// Path to the files to be included in the package.
    /// If this is a directory, all files in the directory will be included.
    /// If this is a zip file, all files in the zip will be included.
    /// </summary>
    string? FilesPath { get; set; }
}

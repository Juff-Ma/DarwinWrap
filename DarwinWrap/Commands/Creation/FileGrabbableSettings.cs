using System.ComponentModel;
using DarwinWrap.Shared.Settings;
using Spectre.Console.Cli;

namespace DarwinWrap.Commands.Creation;

internal class FileGrabbableSettings : CreationSettings, ICanGrabInfosFromFileSettings
{
    [CommandOption("--infos-file")]
    [Description("Executable file name to grab infos from. Defaults to primary file.")]
    [DefaultValue(null)]
    public string? InfosFilePath { get; set; }
    [CommandOption("--file-grab-visible-name")]
    [Description("Whether to grab the visible name from the file.")]
    [DefaultValue(null)]
    public bool FileGrabVisibleName { get; set; }
    [CommandOption("--file-grab-description")]
    [Description("Whether to grab the description from the file.")]
    [DefaultValue(null)]
    public bool FileGrabDescription { get; set; }
    [CommandOption("--file-grab-publisher")]
    [Description("Whether to grab the publisher from the file.")]
    [DefaultValue(null)]
    public bool FileGrabPublisher { get; set; }
    [CommandOption("--file-grab-version")]
    [Description("Whether to grab the version from the file.")]
    [DefaultValue(null)]
    public bool FileGrabVersion { get; set; }
    [CommandOption("--file-grab-architecture")]
    [Description("Whether to grab the architecture from the file.")]
    [DefaultValue(null)]
    public bool FileGrabArchitecture { get; set; }
    [CommandOption("--file-grab-icon")]
    [Description("Whether to grab the icon from the file.")]
    [DefaultValue(null)]
    public bool FileGrabIcon { get; set; }
}

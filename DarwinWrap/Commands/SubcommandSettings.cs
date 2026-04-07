using Spectre.Console.Cli;
using System.ComponentModel;

namespace DarwinWrap.Commands;

internal class SubcommandSettings : GlobalSettings
{
    [CommandOption("-o|--out-file")]
    [Description("Resulting file name")]
    [DefaultValue(null)]
    public string? OutputFile { get; init; }

    [CommandOption("-i|--input")]
    [Description("Primary input file.")]
    [DefaultValue(null)]
    public string? PrimaryInput { get; init; }

    [CommandOption("-a|--aux-input")]
    [Description("Directory or zip file containing all required files.")]
    [DefaultValue(null)]
    public string? AuxiliaryInput { get; init; }
}

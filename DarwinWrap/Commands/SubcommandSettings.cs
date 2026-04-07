using Spectre.Console.Cli;
using System.ComponentModel;

namespace DarwinWrap.Commands;

internal class SubcommandSettings : GlobalSettings
{
    [CommandOption("-o|--out-file")]
    [Description("Resulting file name")]
    public string? OutputFile { get; init; }

    [CommandOption("-i|--input")]
    [Description("Primary input file.")]
    public string? PrimaryInput { get; init; }

    [CommandOption("-a|--aux-input")]
    [Description("Directory or zip file containing all required files.")]
    public string? AuxiliaryInput { get; init; }
}

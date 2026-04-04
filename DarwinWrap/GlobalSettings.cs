using Spectre.Console.Cli;
using System.ComponentModel;

namespace DarwinWrap;

internal class GlobalSettings : CommandSettings
{
    [CommandOption("-v|--verbose")]
    [Description("Enable verbose output")]
    [DefaultValue(false)]
    public bool Verbose { get; init; }

    [CommandOption("--nologo")]
    [Description("Suppress the display of logo and copyright")]
    [DefaultValue(false)]
    public bool NoLogo { get; init; }
}

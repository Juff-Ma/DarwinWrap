namespace DarwinWrap.Shared.Settings;

public interface IScriptPackageSettings : 
    IContainFilesSettings, 
    ISignableSettings
{
    string? InstallScriptFile { get; set; }
    string? UninstallScriptFile { get; set; }
    string? UpdateScriptFile { get; set; }

    bool? RunInstallBeforeUpdate { get; set; }
    bool? RunUninstallBeforeUpdate { get; set; }
}

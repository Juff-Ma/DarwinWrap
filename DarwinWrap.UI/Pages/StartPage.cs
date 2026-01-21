namespace DarwinWrap.UI.Pages;

public partial class StartPage : Page
{
    public StartPage() : base()
    {
        InitializeComponent();

        // TODO: Make embedded button images not embedded but based on files
        InitTooltips();
    }

    private void InitTooltips()
    {
        toolTip.SetToolTip(zipButton, zipButton.AccessibleDescription);
        toolTip.SetToolTip(setupButton, setupButton.AccessibleDescription);
        toolTip.SetToolTip(packageButton, packageButton.AccessibleDescription);
        toolTip.SetToolTip(scriptButton, scriptButton.AccessibleDescription);
        toolTip.SetToolTip(registryButton, registryButton.AccessibleDescription);
        toolTip.SetToolTip(certButton, certButton.AccessibleDescription);
    }
}

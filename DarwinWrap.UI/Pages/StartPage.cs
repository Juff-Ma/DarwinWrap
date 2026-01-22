namespace DarwinWrap.UI.Pages;

public partial class StartPage : Page
{
    public StartPage() : base()
    {
        InitializeComponent();

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

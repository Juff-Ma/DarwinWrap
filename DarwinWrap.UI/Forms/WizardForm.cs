using DarwinWrap.Shared;

namespace DarwinWrap.UI.Forms;

public partial class WizardForm : Form
{
    private readonly IAppController _appController;

    public WizardForm(IAppController controller)
    {
        _appController = controller;
        
        InitializeComponent();

        Icon = SharedResources.MainIcon;
    }

    private void menuFileExit_Click(object sender, EventArgs e)
    {
        _appController.ExitApp();
    }

    private void menuHelpAbout_Click(object sender, EventArgs e)
    {
        AboutForm aboutForm = new(_appController.GetMainAssembly());
        aboutForm.ShowDialog(this);
    }
}

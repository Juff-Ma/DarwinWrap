using DarwinWrap.Shared;
using DarwinWrap.UI.Pages;

namespace DarwinWrap.UI.Forms;

public partial class WizardForm : Form
{
    private readonly IAppController _appController;

    public WizardForm(IAppController controller)
    {
        _appController = controller;
        
        InitializeComponent();

        Icon = SharedResources.MainIcon;

        _startPage = new();
        _startPage.Dock = DockStyle.Fill;
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

    private readonly StartPage _startPage;

    private void WizardForm_Load(object sender, EventArgs e)
    {
        mainPanel.Controls.Clear();
        mainPanel.Controls.Add(_startPage);
    }
}

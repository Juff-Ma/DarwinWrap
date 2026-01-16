using System.Reflection;

namespace DarwinWrap.UI.Forms;

partial class AboutForm : Form
{
    private readonly Assembly _assembly;

    public AboutForm(Assembly versionAssembly)
    {
        _assembly = versionAssembly;

        InitializeComponent();
        Text = $"About {AssemblyTitle}";
        labelProductName.Text = AssemblyProduct;
        labelVersion.Text = $"Version {AssemblyVersion}";
        labelCopyright.Text = AssemblyCopyright;
        labelCompanyName.Text = AssemblyCompany;
        textBoxDescription.Text = AssemblyDescription;

        Icon = SharedResources.MainIcon;
    }

    #region AssemblyInfo

    private string AssemblyTitle
    {
        get
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return Path.GetFileNameWithoutExtension(_assembly.CodeBase);
        }
    }

    private string AssemblyVersion => _assembly.GetName().Version.ToString();

    private string AssemblyDescription
    {
        get
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    private string AssemblyProduct
    {
        get
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    private string AssemblyCopyright
    {
        get
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    private string AssemblyCompany
    {
        get
        {
            object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
    #endregion
}

using System.Reflection;
using System.Runtime.InteropServices;

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

    private string AssemblyTitle => _assembly.GetTitle();

    private string AssemblyVersion => _assembly.GetVersion();

    private string AssemblyDescription => _assembly.GetDescription();

    private string AssemblyProduct => _assembly.GetProduct();

    private string AssemblyCopyright => _assembly.GetCopyright();

    private string AssemblyCompany => _assembly.GetCompany();
    #endregion
}

public static class AttributeExtensions
{
    public static T? GetCustomAttribute<T>(this Assembly assembly) where T : Attribute
    {
        object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
        if (attributes.Length == 0)
        {
            return null;
        }
        return (T)attributes[0];
    }

    public static string GetVersion(this Assembly assembly)
    {
        return assembly.GetName().Version.ToString();
    }

    public static string GetTitle(this Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
        if (attribute is null || string.IsNullOrWhiteSpace(attribute.Title))
        {
            return Path.GetFileNameWithoutExtension(assembly.CodeBase);
        }
        return attribute.Title;
    }

    public static string GetDescription(this Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }

    public static string GetProduct(this Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
        return attribute?.Product ?? string.Empty;
    }

    public static string GetCopyright(this Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>();
        return attribute?.Copyright ?? string.Empty;
    }

    public static string GetCompany(this Assembly assembly)
    {
        var attribute = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
        return attribute?.Company ?? string.Empty;
    }
}

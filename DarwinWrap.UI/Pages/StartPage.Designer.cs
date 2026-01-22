namespace DarwinWrap.UI.Pages
{
    partial class StartPage
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.zipButton = new System.Windows.Forms.Button();
            this.setupButton = new System.Windows.Forms.Button();
            this.packageButton = new System.Windows.Forms.Button();
            this.scriptButton = new System.Windows.Forms.Button();
            this.registryButton = new System.Windows.Forms.Button();
            this.certButton = new System.Windows.Forms.Button();
            this.mainLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 7;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Controls.Add(this.zipButton, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.setupButton, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.packageButton, 5, 1);
            this.tableLayoutPanel.Controls.Add(this.scriptButton, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.registryButton, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.certButton, 5, 3);
            this.tableLayoutPanel.Controls.Add(this.mainLabel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(508, 412);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // zipButton
            // 
            this.zipButton.AccessibleDescription = "Package any files you want. Includes premade configs for common apps.";
            this.zipButton.Image = global::DarwinWrap.UI.SharedResources.FolderButtonImage;
            this.zipButton.Location = new System.Drawing.Point(82, 93);
            this.zipButton.Name = "zipButton";
            this.zipButton.Size = new System.Drawing.Size(75, 75);
            this.zipButton.TabIndex = 0;
            this.zipButton.Text = "ZIP/Folder";
            this.zipButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zipButton.UseVisualStyleBackColor = true;
            // 
            // setupButton
            // 
            this.setupButton.AccessibleDescription = "Package a common setup.exe.";
            this.setupButton.Image = global::DarwinWrap.UI.SharedResources.SetupButtonImage;
            this.setupButton.Location = new System.Drawing.Point(216, 93);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 75);
            this.setupButton.TabIndex = 1;
            this.setupButton.Text = "App Setup";
            this.setupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.setupButton.UseVisualStyleBackColor = true;
            // 
            // packageButton
            // 
            this.packageButton.AccessibleDescription = "Package a Windows app package. E.g. Appx, Msix, AppInstaller";
            this.packageButton.Image = global::DarwinWrap.UI.SharedResources.PackageButtonImage;
            this.packageButton.Location = new System.Drawing.Point(350, 93);
            this.packageButton.Name = "packageButton";
            this.packageButton.Size = new System.Drawing.Size(75, 75);
            this.packageButton.TabIndex = 2;
            this.packageButton.Text = "Package";
            this.packageButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.packageButton.UseVisualStyleBackColor = true;
            // 
            // scriptButton
            // 
            this.scriptButton.AccessibleDescription = "Package Batch/Powershell scripts.";
            this.scriptButton.Image = global::DarwinWrap.UI.SharedResources.ScriptButtonImage;
            this.scriptButton.Location = new System.Drawing.Point(82, 244);
            this.scriptButton.Name = "scriptButton";
            this.scriptButton.Size = new System.Drawing.Size(75, 75);
            this.scriptButton.TabIndex = 3;
            this.scriptButton.Text = "Script";
            this.scriptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.scriptButton.UseVisualStyleBackColor = true;
            // 
            // registryButton
            // 
            this.registryButton.AccessibleDescription = "Package a registry file to be applied to the target.";
            this.registryButton.Image = global::DarwinWrap.UI.SharedResources.RegistryButtonImage;
            this.registryButton.Location = new System.Drawing.Point(216, 244);
            this.registryButton.Name = "registryButton";
            this.registryButton.Size = new System.Drawing.Size(75, 75);
            this.registryButton.TabIndex = 4;
            this.registryButton.Text = "Registry";
            this.registryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.registryButton.UseVisualStyleBackColor = true;
            // 
            // certButton
            // 
            this.certButton.AccessibleDescription = "Package a certificate to be enrolled.";
            this.certButton.Image = global::DarwinWrap.UI.SharedResources.CertButtonImage;
            this.certButton.Location = new System.Drawing.Point(350, 244);
            this.certButton.Name = "certButton";
            this.certButton.Size = new System.Drawing.Size(75, 75);
            this.certButton.TabIndex = 5;
            this.certButton.Text = "Certificate";
            this.certButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.certButton.UseVisualStyleBackColor = true;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.mainLabel, 5);
            this.mainLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainLabel.Location = new System.Drawing.Point(82, 57);
            this.mainLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(343, 13);
            this.mainLabel.TabIndex = 6;
            this.mainLabel.Text = "What kind of source do you want to package?";
            this.mainLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "StartPage";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label mainLabel;
        private ToolTip toolTip;
        internal Button zipButton;
        internal Button setupButton;
        internal Button packageButton;
        internal Button scriptButton;
        internal Button registryButton;
        internal Button certButton;
    }
}
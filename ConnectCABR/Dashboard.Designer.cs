
namespace ConnectCABR
{
    partial class Dashboard
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.SearchEngine = new System.Windows.Forms.Timer(this.components);
            this.FolderSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.CorrectDNS = new System.Windows.Forms.CheckBox();
            this.ClearLogs = new System.Windows.Forms.CheckBox();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.FolderButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DashboardAlertMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DashboardAlert = new System.Windows.Forms.NotifyIcon(this.components);
            this.LoginButton = new System.Windows.Forms.Button();
            this.VelBar = new System.Windows.Forms.TrackBar();
            this.VelLabel = new System.Windows.Forms.Label();
            this.DashboardAlertMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VelBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchEngine
            // 
            this.SearchEngine.Enabled = true;
            this.SearchEngine.Interval = 1;
            this.SearchEngine.Tick += new System.EventHandler(this.SearchEngine_Tick);
            // 
            // FolderSelect
            // 
            this.FolderSelect.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderSelect.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local:";
            // 
            // CorrectDNS
            // 
            this.CorrectDNS.AutoSize = true;
            this.CorrectDNS.Location = new System.Drawing.Point(53, 62);
            this.CorrectDNS.Name = "CorrectDNS";
            this.CorrectDNS.Size = new System.Drawing.Size(84, 17);
            this.CorrectDNS.TabIndex = 1;
            this.CorrectDNS.Text = "Corrigir DNS";
            this.CorrectDNS.UseVisualStyleBackColor = true;
            // 
            // ClearLogs
            // 
            this.ClearLogs.AutoSize = true;
            this.ClearLogs.Enabled = false;
            this.ClearLogs.Location = new System.Drawing.Point(166, 62);
            this.ClearLogs.Name = "ClearLogs";
            this.ClearLogs.Size = new System.Drawing.Size(89, 17);
            this.ClearLogs.TabIndex = 2;
            this.ClearLogs.Text = "Limpar LOGS";
            this.ClearLogs.UseVisualStyleBackColor = true;
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Enabled = false;
            this.FolderTextBox.Location = new System.Drawing.Point(53, 7);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.Size = new System.Drawing.Size(202, 20);
            this.FolderTextBox.TabIndex = 3;
            this.FolderTextBox.Text = "SELECIONE A PASTA DO CA -------------->";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(53, 33);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(202, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Iniciar tratamento";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FolderButton
            // 
            this.FolderButton.Image = ((System.Drawing.Image)(resources.GetObject("FolderButton.Image")));
            this.FolderButton.Location = new System.Drawing.Point(262, 7);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(100, 49);
            this.FolderButton.TabIndex = 5;
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(53, 86);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(309, 16);
            this.ProgressBar.TabIndex = 6;
            // 
            // DashboardAlertMenu
            // 
            this.DashboardAlertMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.DashboardAlertMenu.Name = "LoginAlertMenu";
            this.DashboardAlertMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripMenuItem.Image")));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // DashboardAlert
            // 
            this.DashboardAlert.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.DashboardAlert.ContextMenuStrip = this.DashboardAlertMenu;
            this.DashboardAlert.Icon = ((System.Drawing.Icon)(resources.GetObject("DashboardAlert.Icon")));
            this.DashboardAlert.Visible = true;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(261, 58);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(101, 23);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // VelBar
            // 
            this.VelBar.LargeChange = 4;
            this.VelBar.Location = new System.Drawing.Point(2, 33);
            this.VelBar.Maximum = 4;
            this.VelBar.Minimum = 1;
            this.VelBar.Name = "VelBar";
            this.VelBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VelBar.Size = new System.Drawing.Size(45, 69);
            this.VelBar.TabIndex = 9;
            this.VelBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.VelBar.Value = 1;
            this.VelBar.ValueChanged += new System.EventHandler(this.VelBar_ValueChanged);
            // 
            // VelLabel
            // 
            this.VelLabel.AutoSize = true;
            this.VelLabel.Location = new System.Drawing.Point(2, 94);
            this.VelLabel.Name = "VelLabel";
            this.VelLabel.Size = new System.Drawing.Size(38, 13);
            this.VelLabel.TabIndex = 10;
            this.VelLabel.Text = "Speed";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 112);
            this.Controls.Add(this.VelLabel);
            this.Controls.Add(this.VelBar);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.FolderButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FolderTextBox);
            this.Controls.Add(this.ClearLogs);
            this.Controls.Add(this.CorrectDNS);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 150);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect CA";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.DashboardAlertMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VelBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SearchEngine;
        private System.Windows.Forms.FolderBrowserDialog FolderSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CorrectDNS;
        private System.Windows.Forms.CheckBox ClearLogs;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ContextMenuStrip DashboardAlertMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon DashboardAlert;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TrackBar VelBar;
        private System.Windows.Forms.Label VelLabel;
    }
}


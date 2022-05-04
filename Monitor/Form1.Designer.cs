namespace Monitor
{
    partial class MonitorForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblLookIn = new System.Windows.Forms.Label();
            this.folderBrowserDialogMonitoring = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtbxPathMonitoringFolder = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTipExcelNewFormat = new System.Windows.Forms.ToolTip(this.components);
            this.btnProcesingFilesFolder = new System.Windows.Forms.Button();
            this.txtbxPahtProcesingFolder = new System.Windows.Forms.TextBox();
            this.lblProcesingFilesFolder = new System.Windows.Forms.Label();
            this.chckbxSameDirectory = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialogProcessing = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.lblWarningFolder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLookIn
            // 
            this.lblLookIn.AutoSize = true;
            this.lblLookIn.Location = new System.Drawing.Point(52, 25);
            this.lblLookIn.Name = "lblLookIn";
            this.lblLookIn.Size = new System.Drawing.Size(45, 13);
            this.lblLookIn.TabIndex = 0;
            this.lblLookIn.Text = "Look in:";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(463, 22);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(56, 32);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = " ...";
            this.toolTipExcelNewFormat.SetToolTip(this.btnSelectFolder, "Select folder to motitorising.");
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtbxPathMonitoringFolder
            // 
            this.txtbxPathMonitoringFolder.Location = new System.Drawing.Point(106, 22);
            this.txtbxPathMonitoringFolder.Name = "txtbxPathMonitoringFolder";
            this.txtbxPathMonitoringFolder.ReadOnly = true;
            this.txtbxPathMonitoringFolder.Size = new System.Drawing.Size(343, 20);
            this.txtbxPathMonitoringFolder.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(406, 122);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Start monitoring files";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnProcesingFilesFolder
            // 
            this.btnProcesingFilesFolder.Location = new System.Drawing.Point(463, 65);
            this.btnProcesingFilesFolder.Name = "btnProcesingFilesFolder";
            this.btnProcesingFilesFolder.Size = new System.Drawing.Size(56, 32);
            this.btnProcesingFilesFolder.TabIndex = 8;
            this.btnProcesingFilesFolder.Text = " ...";
            this.toolTipExcelNewFormat.SetToolTip(this.btnProcesingFilesFolder, "Select the folder to put the processed files.");
            this.btnProcesingFilesFolder.UseVisualStyleBackColor = true;
            this.btnProcesingFilesFolder.Click += new System.EventHandler(this.btnProcesingFilesFolder_Click);
            // 
            // txtbxPahtProcesingFolder
            // 
            this.txtbxPahtProcesingFolder.Location = new System.Drawing.Point(106, 72);
            this.txtbxPahtProcesingFolder.Name = "txtbxPahtProcesingFolder";
            this.txtbxPahtProcesingFolder.ReadOnly = true;
            this.txtbxPahtProcesingFolder.Size = new System.Drawing.Size(343, 20);
            this.txtbxPahtProcesingFolder.TabIndex = 7;
            // 
            // lblProcesingFilesFolder
            // 
            this.lblProcesingFilesFolder.AutoSize = true;
            this.lblProcesingFilesFolder.Location = new System.Drawing.Point(8, 75);
            this.lblProcesingFilesFolder.Name = "lblProcesingFilesFolder";
            this.lblProcesingFilesFolder.Size = new System.Drawing.Size(89, 13);
            this.lblProcesingFilesFolder.TabIndex = 9;
            this.lblProcesingFilesFolder.Text = "Procesing Folder:";
            // 
            // chckbxSameDirectory
            // 
            this.chckbxSameDirectory.AutoSize = true;
            this.chckbxSameDirectory.Checked = true;
            this.chckbxSameDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckbxSameDirectory.Location = new System.Drawing.Point(106, 100);
            this.chckbxSameDirectory.Name = "chckbxSameDirectory";
            this.chckbxSameDirectory.Size = new System.Drawing.Size(213, 17);
            this.chckbxSameDirectory.TabIndex = 10;
            this.chckbxSameDirectory.Text = "Use same directory as monitoring folder.";
            this.chckbxSameDirectory.UseVisualStyleBackColor = true;
            this.chckbxSameDirectory.CheckedChanged += new System.EventHandler(this.chckbxSameDirectory_CheckedChanged);
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // lblWarningFolder
            // 
            this.lblWarningFolder.AutoSize = true;
            this.lblWarningFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarningFolder.ForeColor = System.Drawing.Color.Red;
            this.lblWarningFolder.Location = new System.Drawing.Point(244, 45);
            this.lblWarningFolder.Name = "lblWarningFolder";
            this.lblWarningFolder.Size = new System.Drawing.Size(0, 13);
            this.lblWarningFolder.TabIndex = 11;
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 171);
            this.Controls.Add(this.lblWarningFolder);
            this.Controls.Add(this.chckbxSameDirectory);
            this.Controls.Add(this.lblProcesingFilesFolder);
            this.Controls.Add(this.btnProcesingFilesFolder);
            this.Controls.Add(this.txtbxPahtProcesingFolder);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtbxPathMonitoringFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lblLookIn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 210);
            this.MinimumSize = new System.Drawing.Size(550, 210);
            this.Name = "MonitorForm";
            this.Text = "Monitoring files";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLookIn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogMonitoring;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtbxPathMonitoringFolder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolTip toolTipExcelNewFormat;
        private System.Windows.Forms.TextBox txtbxPahtProcesingFolder;
        private System.Windows.Forms.Button btnProcesingFilesFolder;
        private System.Windows.Forms.Label lblProcesingFilesFolder;
        private System.Windows.Forms.CheckBox chckbxSameDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogProcessing;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label lblWarningFolder;
    }
}


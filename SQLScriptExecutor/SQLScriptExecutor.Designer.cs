
namespace SQLScriptExecutor
{
    partial class frmSqlScriptExecutor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSqlScriptExecutor));
            this.btnExecute = new System.Windows.Forms.Button();
            this.cgbConnection = new SQLScriptExecutor.Controls.CustomGroupBox();
            this.connectionControl = new SQLScriptExecutor.Controls.ConnectionControl();
            this.cgbScripts = new SQLScriptExecutor.Controls.CustomGroupBox();
            this.chkUseNotepadPlusPlus = new System.Windows.Forms.CheckBox();
            this.btnViewFile = new System.Windows.Forms.Button();
            this.clbScriptFiles = new System.Windows.Forms.CheckedListBox();
            this.lblScripts = new System.Windows.Forms.Label();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.btnSearchScripts = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.cgbResults = new SQLScriptExecutor.Controls.CustomGroupBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lbxResults = new System.Windows.Forms.ListBox();
            this.cgbConnection.SuspendLayout();
            this.cgbScripts.SuspendLayout();
            this.gbPath.SuspendLayout();
            this.cgbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Enabled = false;
            this.btnExecute.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExecute.Image = global::SQLScriptExecutor.Properties.Resources.Play;
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Location = new System.Drawing.Point(897, 596);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 47);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Ejecutar";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cgbConnection
            // 
            this.cgbConnection.Controls.Add(this.connectionControl);
            this.cgbConnection.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgbConnection.Location = new System.Drawing.Point(12, 12);
            this.cgbConnection.Name = "cgbConnection";
            this.cgbConnection.Size = new System.Drawing.Size(469, 186);
            this.cgbConnection.TabIndex = 15;
            this.cgbConnection.TabStop = false;
            this.cgbConnection.Text = "Conexión";
            // 
            // connectionControl
            // 
            this.connectionControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectionControl.Connection = null;
            this.connectionControl.Database = "";
            this.connectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionControl.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionControl.Location = new System.Drawing.Point(3, 19);
            this.connectionControl.Margin = new System.Windows.Forms.Padding(4);
            this.connectionControl.Name = "connectionControl";
            this.connectionControl.Password = "";
            this.connectionControl.Server = "";
            this.connectionControl.Size = new System.Drawing.Size(463, 164);
            this.connectionControl.TabIndex = 14;
            this.connectionControl.User = "";
            this.connectionControl.OnConnectionChangedEvent += new SQLScriptExecutor.Controls.ConnectionControl.ConnectionChangedEventHandler(this.connectionControl_OnConnectionChangedEvent);
            this.connectionControl.OnConnectionListChangedEvent += new SQLScriptExecutor.Controls.ConnectionControl.ConnectionListChangedEventHandler(this.connectionControl_OnConnectionListChangedEvent);
            // 
            // cgbScripts
            // 
            this.cgbScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cgbScripts.Controls.Add(this.chkUseNotepadPlusPlus);
            this.cgbScripts.Controls.Add(this.btnViewFile);
            this.cgbScripts.Controls.Add(this.clbScriptFiles);
            this.cgbScripts.Controls.Add(this.lblScripts);
            this.cgbScripts.Controls.Add(this.gbPath);
            this.cgbScripts.Enabled = false;
            this.cgbScripts.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgbScripts.Location = new System.Drawing.Point(12, 204);
            this.cgbScripts.Name = "cgbScripts";
            this.cgbScripts.Size = new System.Drawing.Size(469, 385);
            this.cgbScripts.TabIndex = 13;
            this.cgbScripts.TabStop = false;
            this.cgbScripts.Text = "Scripts";
            // 
            // chkUseNotepadPlusPlus
            // 
            this.chkUseNotepadPlusPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUseNotepadPlusPlus.AutoSize = true;
            this.chkUseNotepadPlusPlus.Checked = true;
            this.chkUseNotepadPlusPlus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseNotepadPlusPlus.Location = new System.Drawing.Point(108, 357);
            this.chkUseNotepadPlusPlus.Name = "chkUseNotepadPlusPlus";
            this.chkUseNotepadPlusPlus.Size = new System.Drawing.Size(276, 23);
            this.chkUseNotepadPlusPlus.TabIndex = 18;
            this.chkUseNotepadPlusPlus.Text = "Usar Notepad++ (Si está disponible)";
            this.chkUseNotepadPlusPlus.UseVisualStyleBackColor = true;
            // 
            // btnViewFile
            // 
            this.btnViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewFile.Enabled = false;
            this.btnViewFile.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnViewFile.Image = global::SQLScriptExecutor.Properties.Resources.Notes;
            this.btnViewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewFile.Location = new System.Drawing.Point(3, 333);
            this.btnViewFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.Size = new System.Drawing.Size(97, 47);
            this.btnViewFile.TabIndex = 17;
            this.btnViewFile.Text = "Editar";
            this.btnViewFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewFile.UseVisualStyleBackColor = true;
            this.btnViewFile.Click += new System.EventHandler(this.btnViewFile_Click);
            // 
            // clbScriptFiles
            // 
            this.clbScriptFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbScriptFiles.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbScriptFiles.FormattingEnabled = true;
            this.clbScriptFiles.Location = new System.Drawing.Point(3, 97);
            this.clbScriptFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbScriptFiles.Name = "clbScriptFiles";
            this.clbScriptFiles.Size = new System.Drawing.Size(463, 220);
            this.clbScriptFiles.TabIndex = 0;
            this.clbScriptFiles.ThreeDCheckBoxes = true;
            this.clbScriptFiles.SelectedValueChanged += new System.EventHandler(this.clbScriptFiles_SelectedValueChanged);
            // 
            // lblScripts
            // 
            this.lblScripts.AutoSize = true;
            this.lblScripts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblScripts.Location = new System.Drawing.Point(3, 80);
            this.lblScripts.Name = "lblScripts";
            this.lblScripts.Size = new System.Drawing.Size(58, 18);
            this.lblScripts.TabIndex = 7;
            this.lblScripts.Text = "Scripts:";
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.btnSearchScripts);
            this.gbPath.Controls.Add(this.txtPath);
            this.gbPath.Controls.Add(this.lblFilePath);
            this.gbPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPath.Location = new System.Drawing.Point(3, 19);
            this.gbPath.Margin = new System.Windows.Forms.Padding(0);
            this.gbPath.Name = "gbPath";
            this.gbPath.Padding = new System.Windows.Forms.Padding(0);
            this.gbPath.Size = new System.Drawing.Size(463, 61);
            this.gbPath.TabIndex = 16;
            this.gbPath.TabStop = false;
            // 
            // btnSearchScripts
            // 
            this.btnSearchScripts.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearchScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearchScripts.Image = global::SQLScriptExecutor.Properties.Resources.Find1;
            this.btnSearchScripts.Location = new System.Drawing.Point(421, 16);
            this.btnSearchScripts.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchScripts.Name = "btnSearchScripts";
            this.btnSearchScripts.Size = new System.Drawing.Size(42, 45);
            this.btnSearchScripts.TabIndex = 3;
            this.btnSearchScripts.UseVisualStyleBackColor = true;
            this.btnSearchScripts.Click += new System.EventHandler(this.btnSearchScripts_Click);
            // 
            // txtPath
            // 
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPath.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(58, 16);
            this.txtPath.Margin = new System.Windows.Forms.Padding(0);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(356, 45);
            this.txtPath.TabIndex = 2;
            // 
            // lblFilePath
            // 
            this.lblFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilePath.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(0, 16);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(58, 45);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.Text = "Ruta:";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cgbResults
            // 
            this.cgbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cgbResults.Controls.Add(this.txtContent);
            this.cgbResults.Controls.Add(this.lblContent);
            this.cgbResults.Controls.Add(this.lbxResults);
            this.cgbResults.Enabled = false;
            this.cgbResults.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgbResults.Location = new System.Drawing.Point(487, 12);
            this.cgbResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cgbResults.Name = "cgbResults";
            this.cgbResults.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cgbResults.Size = new System.Drawing.Size(510, 577);
            this.cgbResults.TabIndex = 10;
            this.cgbResults.TabStop = false;
            this.cgbResults.Text = "Resultados";
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(3, 296);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(504, 279);
            this.txtContent.TabIndex = 5;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(3, 277);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(87, 19);
            this.lblContent.TabIndex = 9;
            this.lblContent.Text = "Contenido:";
            // 
            // lbxResults
            // 
            this.lbxResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxResults.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxResults.FormattingEnabled = true;
            this.lbxResults.ItemHeight = 17;
            this.lbxResults.Location = new System.Drawing.Point(3, 18);
            this.lbxResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxResults.Name = "lbxResults";
            this.lbxResults.Size = new System.Drawing.Size(504, 259);
            this.lbxResults.TabIndex = 4;
            this.lbxResults.SelectedValueChanged += new System.EventHandler(this.lbxResults_SelectedValueChanged);
            // 
            // frmSqlScriptExecutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1006, 651);
            this.Controls.Add(this.cgbConnection);
            this.Controls.Add(this.cgbScripts);
            this.Controls.Add(this.cgbResults);
            this.Controls.Add(this.btnExecute);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSqlScriptExecutor";
            this.Text = "SQL SCript Executor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSqlScriptExecutor_FormClosing);
            this.Load += new System.EventHandler(this.frmSqlScriptExecutor_Load);
            this.cgbConnection.ResumeLayout(false);
            this.cgbScripts.ResumeLayout(false);
            this.cgbScripts.PerformLayout();
            this.gbPath.ResumeLayout(false);
            this.gbPath.PerformLayout();
            this.cgbResults.ResumeLayout(false);
            this.cgbResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbScriptFiles;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSearchScripts;
        private System.Windows.Forms.ListBox lbxResults;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblContent;
        private SQLScriptExecutor.Controls.CustomGroupBox cgbResults;
        private SQLScriptExecutor.Controls.CustomGroupBox cgbScripts;
        private SQLScriptExecutor.Controls.ConnectionControl connectionControl;
        private SQLScriptExecutor.Controls.CustomGroupBox cgbConnection;
        private System.Windows.Forms.Label lblScripts;
        private System.Windows.Forms.GroupBox gbPath;
        private System.Windows.Forms.Button btnViewFile;
        private System.Windows.Forms.CheckBox chkUseNotepadPlusPlus;
    }
}


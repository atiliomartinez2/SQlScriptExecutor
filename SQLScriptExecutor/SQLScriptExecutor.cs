using Microsoft.Win32;
using SQLScriptExecutor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLScriptExecutor
{
    public partial class frmSqlScriptExecutor : Form
    {
        #region Constructor
        public frmSqlScriptExecutor()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void btnExecute_Click(object sender, EventArgs e)
        {
            string server = connectionControl.Server;
            string dataBase = connectionControl.Database;
            string user = connectionControl.User;
            string password = connectionControl.Password;
            bool isIntegratedSecurity = string.IsNullOrEmpty(user);
            this.lbxResults.Items.Clear();
            this.txtContent.Text = string.Empty;
            Task.Run(() =>
            {

                foreach (string file in clbScriptFiles.CheckedItems)
                {
                    string scriptPath = Path.Combine(txtPath.Text, file);
                    string logFilePath = Path.Combine(txtPath.Text, file.Replace(".sql", ".txt"));

                    string command = string.Empty;
                    if (isIntegratedSecurity)
                        command = string.Format(@" -E -S ""{0}"" -d {1} -i ""{2}"" -o ""{3}""", server, dataBase, scriptPath, logFilePath);
                    else
                        command = string.Format(@" -U {0} -P {1} -S ""{2}"" -d {3} -i ""{4}"" -o ""{5}""", user, password, server, dataBase, scriptPath, logFilePath);

                    var result = Helper.ExecuteSqlCmd(command);
                    lbxResults.Invoke((Action)(() => lbxResults.Items.Add(file.Replace(".sql", ".txt"))));
                    Application.DoEvents();
                    //sqlcmd -U quipu -P quipu123 -S 10.32.15.20,34710 -d CWNET_NIC -i "%%x" -o "Salida_%%x.txt"
                    //sqlcmd -E -S QUINB016365 -d DATAMERGE -i "%%x" -o "Salida_%%x.txt"
                    //sqlcmd -E -S AZDDXT02\SQL2016,51473 -d vCWNET_NIC -i "%%x" -o "Salida_%%x.txt"
                }
            }
            );

        }
        private void btnSearchScripts_Click(object sender, EventArgs e)
        {
            ClearControls();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.DesktopDirectory;
            string path = string.Empty;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                txtPath.Text = path;
                LoadFiles(path);
            }
        }
        private void btnViewFile_Click(object sender, EventArgs e)
        {
            if (chkUseNotepadPlusPlus.Checked)
            {
                if (checkInstalled("Notepad++"))
                    Process.Start("notepad++", string.Format("\"{0}\"", Path.Combine(txtPath.Text, clbScriptFiles.SelectedItem.ToString())));
                else
                    Process.Start("notepad", string.Format("\"{0}\"", Path.Combine(txtPath.Text, clbScriptFiles.SelectedItem.ToString())));
            }
            else
                Process.Start("notepad", string.Format("\"{0}\"", Path.Combine(txtPath.Text, clbScriptFiles.SelectedItem.ToString())));

        }
        private void clbScriptFiles_SelectedValueChanged(object sender, EventArgs e)
        {
            btnViewFile.Enabled = clbScriptFiles.SelectedItem != null;
        }
        private void connectionControl_OnConnectionChangedEvent(object sender, bool isConnected, System.Data.SqlClient.SqlConnection conn)
        {
            //btnExecute.Enabled = isConnected;
            cgbResults.Enabled = isConnected;
            cgbScripts.Enabled = isConnected;
            btnExecute.Enabled = isConnected && clbScriptFiles.Items.Count > 0;

            if (!isConnected)
                return;

            //Helper.RegistrySetValue("SourceServer", connectionControl.Server);
            //Helper.RegistrySetValue("SourceDatabase", connectionControl.Database);
            //Helper.RegistrySetValue("User", connectionControl.User);
            //Helper.RegistrySetValue("Password", connectionControl.Password);
            Helper.RegistrySetValue("SourceConnectionAlias", connectionControl.GetConnectionAlias());
        }
        private void connectionControl_OnConnectionListChangedEvent(string sender, List<ConnectionItem> currentValues)
        {
            var settings = Helper.LoadSettings();
            settings.ConnectionItems = currentValues;
            Helper.SaveSettings(settings);

        }
        private void frmSqlScriptExecutor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.RegistrySetValue("UseNotepar++", chkUseNotepadPlusPlus.Checked ? "1" : "0");
        }
        private void frmSqlScriptExecutor_Load(object sender, EventArgs e)
        {
            //connectionControl.Server = Helper.RegistryGetValue("SourceServer").ToString();
            //connectionControl.Database = Helper.RegistryGetValue("SourceDatabase").ToString();
            //connectionControl.User = Helper.RegistryGetValue("User").ToString();
            //connectionControl.Password = Helper.RegistryGetValue("Password").ToString();
            var settings = Helper.LoadSettings();
            connectionControl.CurrentConnections = settings.ConnectionItems;
            connectionControl.SetConnectionByAliasn(Helper.RegistryGetValue("SourceConnectionAlias").ToString());
            chkUseNotepadPlusPlus.Checked = Helper.RegistryGetValue("UseNotepar++").ToString() == "1" ? true : false;
        }
        private void lbxResults_SelectedValueChanged(object sender, EventArgs e)
        {
            txtContent.Text = File.ReadAllText(Path.Combine(txtPath.Text, lbxResults.SelectedItem.ToString()));
        }
        #endregion

        #region Private Methods
        private bool checkInstalled(string c_name)
        {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }
            return false;
        }
        private void ClearControls()
        {
            this.txtPath.Text = string.Empty;
            this.clbScriptFiles.Items.Clear();
            this.lbxResults.Items.Clear();
            this.txtContent.Text = string.Empty;
        }
        private void LoadFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles("*.sql"))
                clbScriptFiles.Items.Add(file.Name, true);

            this.btnExecute.Enabled = clbScriptFiles.Items.Count > 0;

        }
        #endregion


    }
}


using SQLScriptExecutor.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLScriptExecutor.Controls
{
    public partial class ConnectionControl : UserControl
    {
        #region Events and delegates
        public delegate void ConnectionChangedEventHandler(object sender, bool isConnected, SqlConnection conn);
        public delegate void ConnectionListChangedEventHandler(string sender, List<ConnectionItem> currentValues);

        public event ConnectionChangedEventHandler OnConnectionChangedEvent;
        public event ConnectionListChangedEventHandler OnConnectionListChangedEvent;
        #endregion

        #region Private variables
        private SqlConnection _conn;
        private bool isAddOrEditMode = false;
        private List<ConnectionItem> currentConnections = new List<ConnectionItem>();
        #endregion

        #region Constructor
        public ConnectionControl()
        {
            InitializeComponent();
        } 
        #endregion

        #region Public properties
        public SqlConnection Connection
        {
            get
            {
                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return _conn != null && _conn.State == ConnectionState.Open;
            }
        }
        public List<ConnectionItem> CurrentConnections
        {
            get
            {
                return currentConnections;
            }
            set
            {
                currentConnections = value;
                FillCombo(null);
            }
        }
        public string Server
        {
            get { return txtServer.Text; }
            set { txtServer.Text = value; }
        }

        public string Database
        {
            get { return txtDatabase.Text; }
            set { txtDatabase.Text = value; }
        }

        public string User
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        #endregion

        #region Private methods
        private void ClearControls()
        {
            txtAlias.Text = string.Empty;
            txtServer.Text = string.Empty;
            txtDatabase.Text = string.Empty;
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void FillCombo(ConnectionItem cnItem)
        {
            cmbAlias.Items.Clear();
            if(CurrentConnections != null)
                CurrentConnections.ForEach(x => cmbAlias.Items.Add(x));
            if (cnItem == null)
            {
                ClearControls();
            }
            else
                cmbAlias.SelectedItem = cnItem;
        }

        private string GetConnectionString()
        {
            if (String.IsNullOrEmpty(txtUser.Text))
                return "Data Source=" + txtServer.Text + ";Initial Catalog=" + txtDatabase.Text + ";"
                       + "Integrated Security=SSPI;";
            else
                return
                    string.Format(
                        "Server={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};",
                        txtServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
        }
        private ConnectionItem ModifyConnection(bool isDelete)
        {
            ConnectionItem cnItem = null;
            if(CurrentConnections != null)
                cnItem = CurrentConnections.Find(x => x.Alias == txtAlias.Text.Trim());
            else
                CurrentConnections = new List<ConnectionItem>();
            if (cnItem != null)
            {
                if (isDelete)
                {
                    currentConnections.Remove(cnItem);
                    cnItem = null;
                }
                else
                {
                    cnItem.Alias = txtAlias.Text.Trim();
                    cnItem.Server = txtServer.Text.Trim();
                    cnItem.Database = txtDatabase.Text.Trim();
                    cnItem.User = txtUser.Text.Trim();
                    cnItem.Password = txtPassword.Text.Trim();
                }
            }
            else
            {
                cnItem = new ConnectionItem();
                cnItem.Alias = txtAlias.Text.Trim();
                cnItem.Server = txtServer.Text.Trim();
                cnItem.Database = txtDatabase.Text.Trim();
                cnItem.User = txtUser.Text.Trim();
                cnItem.Password = txtPassword.Text.Trim();
                CurrentConnections.Add(cnItem);
            }
            if (OnConnectionListChangedEvent != null)
                OnConnectionListChangedEvent(this.Name, CurrentConnections);
            return cnItem;
        }
        private void SetControlsEditMode(bool isEdit)
        {
            this.cmbAlias.Visible = !isEdit;
            this.txtAlias.Visible = isEdit;
            this.txtAlias.ReadOnly =
                this.txtServer.ReadOnly =
                this.txtDatabase.ReadOnly =
                this.txtUser.ReadOnly =
                this.txtPassword.ReadOnly = !isEdit;
        }
        private void SetControlsReadOnly(bool readOnly)
        {
            this.txtServer.Enabled = !readOnly;
            this.txtDatabase.Enabled = !readOnly;
            this.txtUser.Enabled = !readOnly;
            this.txtPassword.Enabled = !readOnly;
        }
        #endregion

        #region Public methods
        public void CloseConnection()
        {
            if (_conn == null)
                return;
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
            toggleButton.Checked = false;
            if (OnConnectionChangedEvent != null)
                OnConnectionChangedEvent(this, false, null);
        }
        public string GetConnectionAlias()
        {
            return txtAlias.Text.Trim();
        }
        public bool OpenConnect()
        {
            if (String.IsNullOrEmpty(txtDatabase.Text) || String.IsNullOrEmpty(txtServer.Text)) return false;

            _conn = new SqlConnection(GetConnectionString());
            try
            {
                _conn.Open();
                if (OnConnectionChangedEvent != null)
                    OnConnectionChangedEvent(this, true, _conn);
                //MessageBox.Show("Success connection");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CloseConnection();
                return false;
            }
        }
        public void SetConnectionByAliasn(string cnn)
        {
            if (CurrentConnections != null)
            {
                var cnItem = CurrentConnections.Find(x => x.Alias == cnn);
                if (cnItem != null)
                    cmbAlias.SelectedItem = cnItem;
            }
        }
        #endregion

        #region Event handlers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddOrEditMode = !isAddOrEditMode;
            this.btnAdd.ImageKey = isAddOrEditMode ? "Save.png" : "Create.png";
            this.btnDelete.Enabled = !isAddOrEditMode;
            this.btnEdit.Enabled = !isAddOrEditMode;
            if (!isAddOrEditMode)
                FillCombo(ModifyConnection(false));

            SetControlsEditMode(isAddOrEditMode);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            FillCombo(ModifyConnection(true));
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAddOrEditMode = !isAddOrEditMode;
            this.btnEdit.ImageKey = isAddOrEditMode ? "Save.png" : "Modify.png";
            this.btnDelete.Enabled = !isAddOrEditMode;
            this.btnAdd.Enabled = !isAddOrEditMode;
            if (!isAddOrEditMode)
                FillCombo(ModifyConnection(false));


            SetControlsEditMode(isAddOrEditMode);
        }
        private void cmbAlias_SelectedValueChanged(object sender, EventArgs e)
        {
            ConnectionItem cnItem = (ConnectionItem)cmbAlias.SelectedItem;
            txtAlias.Text = cnItem.Alias;
            txtServer.Text = cnItem.Server;
            txtDatabase.Text = cnItem.Database;
            txtUser.Text = cnItem.User;
            txtPassword.Text = cnItem.Password;
        }
        private void toggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleButton.Checked)
            {
                if (OpenConnect())
                {
                    SetControlsReadOnly(true);
                }
                else
                {
                    toggleButton.Checked = false;
                    SetControlsReadOnly(false);
                }
            }
            else
            {
                CloseConnection();
                SetControlsReadOnly(false);
            }
        }
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            _conn = null;
        } 
        #endregion

    }
}

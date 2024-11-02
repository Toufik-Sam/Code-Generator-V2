using BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Code_Generator_V2
{
    public partial class frmNewConnection : Form
    {
        private static DataTable _dtDataBaseName;
        public frmNewConnection()
        {
            InitializeComponent();
        }
        public delegate void DataBaseReturn(object sender,string DataBaseName);
        public event DataBaseReturn OnConnectClicked;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!clsDataBase.ValidateDatabaseAccessSettings(cbDatBaseName.SelectedItem.ToString(),txtUserID.Text.ToString(), 
                txtPassword.Text.ToString()))
            {
                MessageBox.Show("Worng UserID or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                Global.DatabaseName = cbDatBaseName.SelectedItem.ToString();
                OnConnectClicked?.Invoke(this, cbDatBaseName.SelectedItem.ToString());
                this.Close();
            }
        }
        private void _FillDataBaseName()
        {
            _dtDataBaseName = clsDataBase.GetAllDataBaseNames();
            if (_dtDataBaseName.Rows.Count>0)
            {
                foreach (DataRow row in _dtDataBaseName.Rows)
                    cbDatBaseName.Items.Add(row["name"]);
                cbDatBaseName.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No DataBases Found!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void frmNewConnection_Load(object sender, EventArgs e)
        {
            _FillDataBaseName();
        }
    }
}

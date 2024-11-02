using BusinessLayer;
using Code_Generator_V2.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Code_Generator_V2
{
    public partial class frmBankOfCodes : Form
    {
        private int _CurrentCodeID = -1;
        private string _CurrentCodeTitle = "";
        private string _CurrentMainCode = "";
        private static DataTable _dtCodeTitles;
        public frmBankOfCodes()
        {
            InitializeComponent();
            BtnEdit.Enabled = false;
            btnDelete.Enabled = false; 
        }
        private void LoadData()
        {
            flySearchedCode.Controls.Clear();
            
            _dtCodeTitles = clsCodeBank.GetTopTenCodes();
            if(_dtCodeTitles!=null)
            {
                foreach (DataRow row in _dtCodeTitles.Rows)
                {
                    ctrlBankOfCodeElement Code = new ctrlBankOfCodeElement();
                    Code.LoadData((int)row["CodeID"], (string)row["CodeTitle"], (string)row["Code"]);
                    Code.OnCodeTiteClicked += CodeTitleClicked;
                    flySearchedCode.Controls.Add(Code);
                }
                
            }
        }
        private bool _InputValidate()
        {
            if (txtCodeTitle.Text == "")
            {
                MessageBox.Show("Code Title Cannot Be Empty!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (rtxMainCode.Text == "")
            {
                MessageBox.Show("Empty Code!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!_InputValidate())
                return;
            clsCodeBank NewCode = new clsCodeBank();
            NewCode.CodeTitle = txtCodeTitle.Text.Trim();
            NewCode.MainCode = rtxMainCode.Text.Trim();
            if (NewCode.Save())
            {
                MessageBox.Show("Your Code Has Been SuccessFully Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDelete.Enabled = true;
                BtnEdit.Enabled = true;
                _CurrentCodeID = NewCode.CodeID;
                LoadData();
            }
            else
                MessageBox.Show("Your Code Has Not Been SuccessFully Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void CodeTitleClicked(object sender,ctrlBankOfCodeElement.CodeClickedEventArgs e)
        {
            BtnEdit.Enabled = true;
            btnDelete.Enabled = true;
            _CurrentCodeID = e.CodeID;
            _CurrentCodeTitle = e.CodeTitle;
            _CurrentMainCode = e.Code;
            txtCodeTitle.Text = _CurrentCodeTitle;
            rtxMainCode.Text = _CurrentMainCode;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            flySearchedCode.Controls.Clear();
            DataTable _dtSearchCode = clsCodeBank.Search(txtSearchBar.Text.ToString());
            if (_dtSearchCode.Rows.Count>0)
            {
                foreach (DataRow row in _dtSearchCode.Rows)
                {
                    ctrlBankOfCodeElement Code = new ctrlBankOfCodeElement();
                    Code.LoadData((int)row["CodeID"], (string)row["CodeTitle"], (string)row["Code"]);
                    Code.OnCodeTiteClicked += CodeTitleClicked;
                    flySearchedCode.Controls.Add(Code);
                }
            }
            else
                MessageBox.Show("No Code was Found!", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSearchBar.Text = "";
            LoadData();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!_InputValidate())
                return;
            clsCodeBank EditCode = clsCodeBank.Find(_CurrentCodeID);
            if(EditCode!=null)
            {
                EditCode.CodeTitle = txtCodeTitle.Text;
                EditCode.MainCode = rtxMainCode.Text;
                if(EditCode.Save())
                {
                    MessageBox.Show("Your Code Has Been SuccessFully Edited!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                    MessageBox.Show("Your Code Has Not Been SuccessFully Edited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(clsCodeBank.DeleteCode(_CurrentCodeID))
            {
                MessageBox.Show("Your Code Has Been SuccessFully Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDelete.Enabled = false;
                BtnEdit.Enabled = false;
                txtCodeTitle.Text = "";
                rtxMainCode.Text = "";
                LoadData();
            }
            else
                MessageBox.Show("Your Code Has Not Been SuccessFully Deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void frmBankOfCodes_Load(object sender, EventArgs e)
        {
            if (clsDataBase.IsConnectivityAvailable("CodeGeneratorDB"))
                LoadData();
            else
            {
                MessageBox.Show("Error Go Back To Generator and Connect First !!",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAddNew.Enabled = false;
                btnSearch.Enabled = false;
            }

        }
    }
}

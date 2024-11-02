using BusinessLayer;
using Code_Generator_V2.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Code_Generator_V2
{
    public partial class frmGenerator : Form
    {
        private static DataTable _dtDataBaseTables;
        private static DataTable _dtTableData;
        private DataTable _dtTableColumns;
        private string _DataBaseName = "";
        private string _SelectedTable = "";
        private StringBuilder _SqlQuery =new StringBuilder();
        private StringBuilder _DataAccessLayer =new StringBuilder();
        private StringBuilder _BusinessLayer = new StringBuilder();
        private StringBuilder _PrisentationLayer = new StringBuilder();
        private StringBuilder _DesginerLayer = new StringBuilder();
        public frmGenerator()
        {
            InitializeComponent();

        }
        private bool _ValidateConnection()
        {
            return _DataBaseName == "" ? false : true;
        }
        private void _LoadDataBaseTables(string DataBaseName)
        {
            flyDataBaseTables.Controls.Clear();
            _dtDataBaseTables = clsDataBase.GetAllTablesByDataBaseName(DataBaseName);
            if (_dtDataBaseTables.Rows.Count > 0)
            {
                int Count = 1;
                foreach (DataRow row in _dtDataBaseTables.Rows)
                {
                    string Temp= row["name"].ToString();
                    if (Temp == "spt_fallback_db" || Temp == "spt_fallback_dev" || Temp == "spt_fallback_usg" 
                        || Temp == "spt_fallback_monitor" || Temp == "MSreplication_options")
                        break;
                    ctrlDataBaseTableName TableName = new ctrlDataBaseTableName();
                    TableName.LoadData(row["name"].ToString());
                    if (Count % 2 != 0)
                        TableName.BackColor = Color.SkyBlue;
                    else
                        TableName.BackColor = Color.Wheat;
                    TableName.OnTableNameClicked += OnTableNameClicked;
                    flyDataBaseTables.Controls.Add(TableName);
                    Count++;
                }
            }
            else
                MessageBox.Show("No DataBase Tables Found!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private bool _LoadTableColumns(string TableName)
        {
            
            _dtTableData = clsDataBase.GetAllColumnByTableName(TableName, _DataBaseName);
            if (_dtDataBaseTables.Rows.Count > 0)
            {
                _dtTableColumns = _dtTableData.DefaultView.ToTable(false, "COLUMN_NAME", "DATA_TYPE");
                dgvTableColumns.DataSource = _dtTableColumns;
                return true;
            }
            return false;
        }
        private void _FillDataGridTableColumns(string TableName)
        {
            if(_LoadTableColumns(TableName))
            {
                DataGridViewCheckBoxColumn dgvchb1 = new DataGridViewCheckBoxColumn();
                dgvchb1.HeaderText = "Check";
                DataGridViewCheckBoxColumn dgvchb2 = new DataGridViewCheckBoxColumn();
                dgvchb2.HeaderText = "Where";
                dgvTableColumns.Columns.Add(dgvchb1);
                dgvTableColumns.Columns.Add(dgvchb2);
                DataGridViewTextBoxColumn dgvTxt1 = new DataGridViewTextBoxColumn();
                dgvTxt1.HeaderText = "Column Name";
                DataGridViewTextBoxColumn dgvTxt2 = new DataGridViewTextBoxColumn();
                dgvTxt2.HeaderText = "Column Width";
                dgvTxt2.ValueType = typeof(int);
                dgvTableColumns.Columns.Add(dgvTxt1);
                dgvTableColumns.Columns.Add(dgvTxt2);
                DataGridViewComboBoxColumn dgvcmb = new DataGridViewComboBoxColumn();
                dgvcmb.HeaderText = "Control Type";
                dgvcmb.Items.Add("TextBox");
                dgvcmb.Items.Add("Label");
                dgvcmb.Items.Add("DateTimePicker");
                dgvcmb.Items.Add("ComboBox");
                dgvcmb.Items.Add("PictureBox");
                dgvcmb.Items.Add("CheckBox");
                dgvcmb.FlatStyle = FlatStyle.Popup;
                dgvcmb.DefaultCellStyle.BackColor = Color.Silver;
               
                dgvTableColumns.Columns.Add(dgvcmb);
                //DataGridViewCheckBoxColumn dgvchb3 = new DataGridViewCheckBoxColumn();
                //dgvchb3.HeaderText = "Order";
                //dgvTableColumns.Columns.Add(dgvchb3);
                dgvTableColumns.Columns[0].Width = 200;
                dgvTableColumns.Columns[1].Width = 148;
                dgvTableColumns.Columns[2].Width = 50;
                dgvTableColumns.Columns[3].Width = 50;
                dgvTableColumns.Columns[4].Width = 210;
                dgvTableColumns.Columns[5].Width = 210;
                dgvTableColumns.Columns[6].Width = 200;
                //dgvTableColumns.Columns[7].Width = 50;
                dgvTableColumns.RowTemplate.Height = 150;
                dgvTableColumns.RowHeadersVisible = false;
                this.dgvTableColumns.DefaultCellStyle.Font= new Font("Tahoma", 9);
                dgvTableColumns.Rows[0].Selected = false;
                //dgvTableColumns.ColumnHeadersVisible = false;
                dgvTableColumns.AllowUserToAddRows = false;
                dgvTableColumns.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                dgvTableColumns.EnableHeadersVisualStyles = false;
                int Count = 1;
                foreach (DataGridViewRow row in dgvTableColumns.Rows)
                {
                    if (Count % 2 != 0)
                    {
                        row.Cells[0].Style.BackColor = Color.Wheat;
                        row.Cells[1].Style.BackColor = Color.Wheat;
                        row.Cells[2].Style.BackColor = Color.Wheat;
                        row.Cells[3].Style.BackColor = Color.Wheat;
                        row.Cells[4].Style.BackColor = Color.Wheat;
                        row.Cells[5].Style.BackColor = Color.Wheat;
                        row.Cells[6].Style.BackColor = Color.Silver;
                        //row.Cells[7].Style.BackColor = Color.Wheat;
                    }
                    else
                    {
                        row.Cells[0].Style.BackColor = Color.SkyBlue;
                        row.Cells[1].Style.BackColor = Color.SkyBlue;
                        row.Cells[2].Style.BackColor = Color.SkyBlue;
                        row.Cells[3].Style.BackColor = Color.SkyBlue;
                        row.Cells[4].Style.BackColor = Color.SkyBlue;
                        row.Cells[5].Style.BackColor = Color.SkyBlue;
                        row.Cells[6].Style.BackColor = Color.Silver;
                        //row.Cells[7].Style.BackColor = Color.SkyBlue;
                    }
                    Count++;
                    row.Cells[5].Value = 0;
                    row.Cells[6].Value = "TextBox";
                    row.Height = 35;
                }
            }
            else
                MessageBox.Show("The Selected Table is Empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OnTableNameClicked(object sender,string TableName)
        {
            _SelectedTable = TableName;
            if(dgvTableColumns.Rows.Count>0)
            {
                _dtTableColumns = null;
                dgvTableColumns.Columns.Clear();
            }
            _FillDataGridTableColumns(TableName);
        }
        private void OnConnectClicked(object sender, string DataBaseName)
        {
            _DataBaseName = DataBaseName;
             
            _LoadDataBaseTables(_DataBaseName);
        }
        private void frmGenerator_Load(object sender, EventArgs e)
        {
            if(clsDataBase.IsConnectivityAvailable(Global.DatabaseName))
            {
                _LoadDataBaseTables(Global.DatabaseName);
                _DataBaseName = Global.DatabaseName;
            }
        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            string quote = "\"";
            _SqlQuery.Append("string ConnectionString=" + quote + clsDataBase.
                GetDataBaseConnectionString(_DataBaseName) + quote + ";");
            rtxCode.Text =_DataAccessLayer.ToString();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxCode.SelectAll();
            rtxCode.Focus();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxCode.SelectedText);
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxCode.Text);
            rtxCode.Text = "";
        }
        private List<Tuple<string,string>>GetCheckedSelectedItemsWithTheirDataTypes()
        {
            var SelectedItemsWithDataTypes = new List<Tuple<string, string>>();
            foreach (DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value))
                    SelectedItemsWithDataTypes.Add(Tuple.Create((string)row.Cells[0].Value,(string) row.Cells[1].Value));
            }
            return SelectedItemsWithDataTypes;
        }
        private List<Tuple<string,string>>GetWhereSelectedItemsWithDataTypes()
        {
            var WhereSelectedItems = new List<Tuple<string, string>>();
            foreach (DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (Convert.ToBoolean(row.Cells[3].Value))
                    WhereSelectedItems.Add(Tuple.Create((string)row.Cells[0].Value, (string)row.Cells[1].Value));
            }
            return WhereSelectedItems;
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            _SqlQuery.Append(clsUtil.GetAllElements(_SelectedTable));
            _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassGetAllItems(_DataBaseName, _SelectedTable));
            _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassGetAllItems(_SelectedTable));
            rtxCode.Text = _SqlQuery.ToString();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            _SqlQuery.Append(clsUtil.InsertIntoStatement(_dtTableData, _DataBaseName, _SelectedTable));
            _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassDataAddNew(_dtTableData, _DataBaseName,_SelectedTable));
            _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassAddNew(_dtTableData, _SelectedTable, _DataBaseName));
            rtxCode.Text = _SqlQuery.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            List<Tuple<string, string>> vSelected = GetCheckedSelectedItemsWithTheirDataTypes();
            List<Tuple<string, string>> vWhere = GetWhereSelectedItemsWithDataTypes();
            _SqlQuery.Append(clsUtil.UpdateStatement(vSelected,vWhere, _SelectedTable, _DataBaseName));
            _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassDataUpdate(vSelected, vWhere,_DataBaseName,_SelectedTable));
            _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassUpdate(_dtTableData, _SelectedTable, _DataBaseName));
            rtxCode.Text = _SqlQuery.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            _SqlQuery.Append(clsUtil.DeletStatement(GetWhereSelectedItemsWithDataTypes(), _SelectedTable));
            _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassDataDelete(GetWhereSelectedItemsWithDataTypes(), _DataBaseName, _SelectedTable));
            _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassDeleteFunction(_DataBaseName, _SelectedTable));
            rtxCode.Text = _SqlQuery.ToString();
        }
        private void btnSqlQuery_Click(object sender, EventArgs e)
        {
           
            rtxCode.Text = _SqlQuery.ToString();
        }
        private void btnDataAcessLayer_Click(object sender, EventArgs e)
        {
            rtxCode.Text = _DataAccessLayer.ToString();
        }
        private void btnBusinessLayer_Click(object sender, EventArgs e)
        {
            rtxCode.Text = _BusinessLayer.ToString();
        }
        private void btnPresentationLayer_Click(object sender, EventArgs e)
        {
            rtxCode.Text = _PrisentationLayer.ToString();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            List<Tuple<string, string>> vWhereSelectedItems = GetWhereSelectedItemsWithDataTypes();
            List<Tuple<string, string>> vCheckedSelectedItems = GetCheckedSelectedItemsWithTheirDataTypes();
            bool Condition = (vWhereSelectedItems.Count > 0);
            if (vCheckedSelectedItems == null && vWhereSelectedItems == null)
                return;
            _SqlQuery.Append(clsUtil.SelectItemsStatment(vCheckedSelectedItems, vWhereSelectedItems, _SelectedTable, Condition));
            if (vCheckedSelectedItems == null || vWhereSelectedItems==null)
            {
                _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassDataGetItemsInfoByKeys(_DataBaseName,
                   _SelectedTable, vCheckedSelectedItems, vWhereSelectedItems));
                _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassFind(vCheckedSelectedItems, vWhereSelectedItems,
                    _DataBaseName, _SelectedTable));

            }
            else
            {
                _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassDataGetItemsInfoByKeys(_DataBaseName,
                   _SelectedTable, vCheckedSelectedItems, vWhereSelectedItems));
                _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassFind(
                  vCheckedSelectedItems, vWhereSelectedItems, _DataBaseName, _SelectedTable));
            }


            rtxCode.Text = _SqlQuery.ToString();
        }
        private void _GenerateToolsCode(ref StringBuilder n,ref StringBuilder p,ref StringBuilder k,
            string SelectedControl,string FieldName)
        {
            n.Append(clsToolsDesginerCode.FormAddControls(clsUtil.GetItemPrefix(SelectedControl) + FieldName));
            p.Append(clsToolsDesginerCode.InitializeComponents(clsUtil.GetItemPrefix(SelectedControl) +FieldName,SelectedControl));
            k.Append(clsToolsDesginerCode.EndRegion(clsUtil.GetItemPrefix(SelectedControl) + FieldName, SelectedControl));
        }
        private void btnCreateTools_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            bool flag = false;
            StringBuilder s = new StringBuilder();
            StringBuilder n = new StringBuilder();
            StringBuilder p = new StringBuilder();
            StringBuilder k = new StringBuilder();
           
            p.Append("//This Part Is For Initialize Component Procedure\n");
            p.Append("this.components = new System.ComponentModel.Container();\n");
            n.Append("\n//This part Should be Added To Form Section In the Initialize Component Procedure//\n");
            k.Append("#endregion\n");
            foreach(DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value))
                {
                    flag = true;
                    switch (Convert.ToString(row.Cells[6].Value))
                    {
                        case "TextBox":
                            s.Append(clsToolsDesginerCode.TextBoxDesignerCode(clsUtil.GetItemPrefix
                                (Convert.ToString(row.Cells[6].Value))+ Convert.ToString(row.Cells[0].Value))+"\n");
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), 
                                Convert.ToString(row.Cells[0].Value));
                            break;
                        case "Label":
                            s.Append(clsToolsDesginerCode.LabelDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[0].Value)) + "\n");
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[0].Value));
                            break;
                        case "DateTimePicker":
                            s.Append(clsToolsDesginerCode.DateTimePickerDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value)));
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[0].Value));
                            break;
                        case "CheckBox":
                            s.Append(clsToolsDesginerCode.CheckBoxDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value), Convert.ToString(row.Cells[0].Value)) + "\n");
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[0].Value));
                            break;
                        case "ComboBox":
                            s.Append(clsToolsDesginerCode.ComboBoxDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value)));
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[0].Value));
                            break;
                        case "PictureBox":
                            s.Append(clsToolsDesginerCode.PictureBoxDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value)));
                            _GenerateToolsCode(ref n, ref p, ref k, Convert.ToString(row.Cells[6].Value), Convert.ToString(row.Cells[0].Value));
                            break;

                    }
                }
            }
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            if (!flag)
                return;
            _DesginerLayer.Append(p);
            _DesginerLayer.Append(s);
            _DesginerLayer.Append(n);
            _DesginerLayer.Append(k);
            rtxCode.Text = _DesginerLayer.ToString();
        }
        private void btnDesignerLayer_Click(object sender, EventArgs e)
        {
            rtxCode.Text = _DesginerLayer.ToString();
        }
        private void btnCreateCmb_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            StringBuilder s = new StringBuilder();
            StringBuilder n = new StringBuilder();
            foreach(DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value) && Convert.ToString(row.Cells[6].Value) == "ComboBox")
                {
                    n.Append(clsToolsDesginerCode.ComboBoxDesignerCode(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value)));
                    s.Append(clsPresentationLayerGenerator.GenerateFillComboBox(clsUtil.GetItemPrefix(Convert.ToString(row.Cells[6].Value)) + Convert.ToString(row.Cells[0].Value), _SelectedTable, Convert.ToString(row.Cells[0].Value)));
                }
                    
            }
            _DesginerLayer = n;
            _PrisentationLayer = s;
            rtxCode.Text = s.ToString();
        }
        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            flyDataBaseTables.Controls.Clear();
            _LoadDataBaseTables(_DataBaseName);
        }
        private void btnCreateDataGridView_Click(object sender, EventArgs e)
        {
            if (!_ValidateConnection())
                return;
            List<string> vSelectedItems= new List<string> { };
            var TitlesAndWidth= new List<Tuple<string, string>>();
            foreach (DataGridViewRow row in dgvTableColumns.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value))
                {
                    vSelectedItems.Add(Convert.ToString(row.Cells[0].Value));
                    TitlesAndWidth.Add(Tuple.Create(Convert.ToString(row.Cells[4].Value), Convert.ToString(row.Cells[5].Value)));
                }
            }
            _SqlQuery.Clear();
            _DataAccessLayer.Clear();
            _BusinessLayer.Clear();
            _PrisentationLayer.Clear();
            _DesginerLayer.Clear();
            _SqlQuery.Append(clsUtil.GetAllElements(_SelectedTable));
            _DataAccessLayer.Append(clsDataAcessLayerGenerator.GenerateClassGetAllItems(_DataBaseName, _SelectedTable));
            _BusinessLayer.Append(clsBusinessLayerGenerator.GenerateClassGetAllItems(_SelectedTable));
            _PrisentationLayer.Append(clsPresentationLayerGenerator.GenerateDataGridView(vSelectedItems, TitlesAndWidth, 
                _SelectedTable + "Items", _SelectedTable));
            _DesginerLayer.Append("Add Control To Form Section\n");
            _DesginerLayer.Append(clsToolsDesginerCode.FormAddControls("dgv" + _SelectedTable + "Items"));
            _DesginerLayer.Append("Add This To The First Section To Initilize Component\n");
            _DesginerLayer.Append(clsToolsDesginerCode.InitializeComponents("dgv"+_SelectedTable+"items","DataGridView"));
            _DesginerLayer.Append(clsToolsDesginerCode.DataGridViewDesignerCode(_SelectedTable + "Items"));
            _DesginerLayer.Append("#endregion\n");
            _DesginerLayer.Append(clsToolsDesginerCode.EndRegion("dgv" + _SelectedTable + "Items", "DataGridView"));
            rtxCode.Text = _DesginerLayer.ToString();
        }
        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSelectAll.Checked)
            {
                foreach(DataGridViewRow row in dgvTableColumns.Rows)
                    row.Cells[2].Value = true;

            }
            else
            {
                foreach (DataGridViewRow row in dgvTableColumns.Rows)
                    row.Cells[2].Value = false;
            }
        }
        private void btnNewConnection_Click_1(object sender, EventArgs e)
        {
            frmNewConnection NewConnection = new frmNewConnection();
            NewConnection.OnConnectClicked += OnConnectClicked;
            NewConnection.ShowDialog();
        }
    }
}

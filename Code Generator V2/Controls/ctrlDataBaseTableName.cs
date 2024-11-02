using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_V2.Controls
{
    public partial class ctrlDataBaseTableName : UserControl
    {
        private string _TableName = "";
        public ctrlDataBaseTableName()
        {
            InitializeComponent();
        }
        public delegate void TableNameClicked(object sender, string TableName);
        public event TableNameClicked OnTableNameClicked;
        public void LoadData(string TableName)
        {
            _TableName = TableName;
            lblTableName.Text = _TableName;
        }

        private void ctrlDataBaseTableName_Click(object sender, EventArgs e)
        {
            OnTableNameClicked?.Invoke(this, _TableName);
        }
    }
}

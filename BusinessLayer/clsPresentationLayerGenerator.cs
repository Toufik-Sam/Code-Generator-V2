using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class clsPresentationLayerGenerator
    {
        public static string GenerateFillComboBox(string ComboBoxName,string TableName,string SelectedField)
        {
            StringBuilder s = new StringBuilder();
            s.Append("private void Fill" + ComboBoxName + "()\n");
            s.Append("{\n");
            s.Append("DataTable _dt" + TableName + "\"=cls" + TableName + ".GetAllItems();\n");
            s.Append("if(_dt" + ComboBoxName + ".Rows.Count>0)\n");
            s.Append("{\n");
            s.Append("foreach(DataRow row in _dt" + ComboBoxName + ")\n");
            s.Append("{\n");
            s.Append(ComboBoxName + ".Items.Add(row[" + "\"" + SelectedField + "\"])\n");
            s.Append("}\n");
            s.Append(ComboBoxName + ".SelectedIndex="+"0;");
            s.Append("}\n");
            s.Append("else\n");
            s.Append("{\n");
            s.Append("MessageBox(\" No Items Found!!\"" + ",\"Information\"," + "MessageBoxButtons.OK," + "MessageBoxIcon.Exclamation);\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateDataGridView(List<string>vSelectedItems, List<Tuple<string, string>>TitlesAndWidth,
            string DataGridViewName,string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("private static DataTable _dtElements;\n");
            s.Append("private DataTable _dtItems;\n");
            s.Append("private void Generatedgv" + DataGridViewName + "()\n");
            s.Append("{\n");
            s.Append("_dtElements=cls" + TableName + ".GetAllItems();\n");
            s.Append("_dtItems=_dtElements.DefaultView.ToTable(false,");
            foreach (string item in vSelectedItems)
                s.Append(item + ",");
            s.Length--;
            s.Append(");\n");
            s.Append("dgv"+DataGridViewName + ".DataSource" + "=_dtItems\n");
            s.Append("if(dgv" + DataGridViewName + ".Rows.Count>0)\n");
            s.Append("{\n");
            int Counter = 0;
            foreach(var Item in TitlesAndWidth)
            {
                s.Append("dgv" + DataGridViewName + ".Columns[" + Counter + "].HeaderText=" + Item.Item1 + ";\n");
                s.Append("dgv" + DataGridViewName + ".Columns[" + Counter + "].Width=" + Item.Item2 + ";\n");
                Counter++;
            }
            s.Append("}\n");
            s.Append("}\n");
            return s.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class clsUtil
    {
        public static string AttributesLoop(DataTable _dtColumn,string PrimaryKey)
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            for(int i=0;i<_dtColumn.Rows.Count;i++)
            {
                if ((string)_dtColumn.Rows[i][0] == PrimaryKey)
                    continue;
                s.Append(_GetElementType((string)_dtColumn.Rows[i][1]) + " " + (string)_dtColumn.Rows[i][0]+", ");
            }
            s.Length--;
            s.Append(")\n");
            return s.ToString();
        }
        public static string AttributesLoop(List<Tuple<string, string>> vSelectedItemsWithDataTypes, List<Tuple<string, string>> vWhereItemsWithDataTypes)
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            foreach(var item in vSelectedItemsWithDataTypes)
                s.Append(_GetElementType(item.Item2) + " " + item.Item1 + ", ");
            foreach (var item in vWhereItemsWithDataTypes)
                s.Append(_GetElementType(item.Item2)+" " + item.Item1 + ",");
            s.Length--;
            s.Append(")");
            return s.ToString();
            
        }
        public static string AttributesLoop(List<Tuple<string, string>> vWhereItemsWithDataTypes)
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            foreach (var item in vWhereItemsWithDataTypes)
                s.Append(_GetElementType(item.Item2) + " " + item.Item1 + ",");
            s.Length--;
            s.Append(")");
            return s.ToString();

        }
        public static string AttributesLoopWithRef(List<Tuple<string, string>> vSelectedItemsWithDataTypes, 
            List<Tuple<string, string>> vWhereItemsWithDataTypes)
        {
            
            StringBuilder s = new StringBuilder();
            s.Append("(");
            foreach(var WhereItem in vWhereItemsWithDataTypes)
                s.Append(_GetElementType(WhereItem.Item2) + " " + WhereItem.Item1 + ",");

            foreach (var SelectedItem in vSelectedItemsWithDataTypes )
                s.Append("ref " + _GetElementType(SelectedItem.Item2) + " " + SelectedItem.Item1 + ",");
            s.Length--;
            s.Append(")\n");
            return s.ToString();
        }
        public static string AttributesLoopWithRef(DataTable _dtColumns, string PrimaryKey)
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            s.Append("int " + PrimaryKey + ",");
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                if (PrimaryKey == _dtColumns.Rows[i][0].ToString())
                    continue;
                switch (_dtColumns.Rows[i][1])
                {
                    case "int":
                        s.Append("ref int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "tinyint":
                        s.Append("ref int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "smallint":
                        s.Append("ref int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "smallmoney":
                        s.Append("ref float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "float":
                        s.Append("ref float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "real":
                        s.Append("ref float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "datetime":
                        s.Append("ref DateTime " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "bit":
                        s.Append("ref bool " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "nvarchar":
                        s.Append("ref string " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "varchar":
                        s.Append("ref string " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "text":
                        s.Append("ref string " + _dtColumns.Rows[i][0] + ",");
                        break;
                }
            }
            s.Length--;
            s.Append(");\n");
            return s.ToString();
        }
        public static string AttributesLoopWithThis(DataTable _dtColumns, string PrimaryKey)
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                if (PrimaryKey == _dtColumns.Rows[i][0].ToString())
                    continue;
                s.Append("this." + _dtColumns.Rows[i][0] + ",");
            }
            s.Length--;
            s.Append(");\n");
            return s.ToString();
        }
        public static string AttributeForFindFunction(DataTable _dtColumns,List<Tuple<string,string>>vWhere, string PrimaryKey)
        {
            StringBuilder s = new StringBuilder();
            int Index = 0;
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                if (_dtColumns.Rows[i][0].ToString() == PrimaryKey)
                    continue;
                var item = vWhere.FirstOrDefault(eri => eri.Item1 == _dtColumns.Rows[i][0].ToString());
                if (item != null)
                    continue;
                switch (_dtColumns.Rows[i][1])
                {
                    case "int":
                        s.Append("int " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "tinyint":
                        s.Append("int " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "smallint":
                        s.Append("int " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "smallmoney":
                        s.Append("float " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "float":
                        s.Append("float " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "real":
                        s.Append("float " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "datetime":
                        s.Append("DateTime " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "bit":
                        s.Append("bool " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "nvarchar":
                        s.Append("string " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "varchar":
                        s.Append("string " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                    case "text":
                        s.Append("string " + _dtColumns.Rows[i][0] + ";\n");
                        break;
                }
            }

            return s.ToString();
        }
        public static string AttributeForFindReturn(DataTable _dtColumns)
        {
            StringBuilder s = new StringBuilder();
            int Index = 0;
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                switch (_dtColumns.Rows[i][1])
                {
                    case "int":
                        s.Append("int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "tinyint":
                        s.Append("int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "smallint":
                        s.Append("int " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "smallmoney":
                        s.Append("float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "float":
                        s.Append("float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "real":
                        s.Append("float " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "datetime":
                        s.Append("DateTime " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "bit":
                        s.Append("bool " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "nvarchar":
                        s.Append("string " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "varchar":
                        s.Append("string " + _dtColumns.Rows[i][0] + ",");
                        break;
                    case "text":
                        s.Append("string " + _dtColumns.Rows[i][0] + ",");
                        break;
                }
            }

            return s.ToString();
        }
        public static string SelectItemsStatment(List<Tuple<string,string>> vSelectedColumns, List<Tuple<string, string>> vConditionElements, 
            string TableName, bool Condition)
        {
            StringBuilder s = new StringBuilder();
            s.Append("Select ");
            if (vSelectedColumns.Count!=0)
            {
                foreach (var item in vSelectedColumns)
                {
                    s.Append(item.Item1);
                    s.Append(",");
                }
                s.Length--;
            }
            else
                s.Append(" *");
            
            s.Append(" From ");
            s.Append(TableName);
            if (Condition == true)
            {
                s.Append(" Where ");
                int Count = 0;
                foreach (var item in vConditionElements)
                {
                    if (Count > 0)
                        s.Append(" and ");
                    s.Append(item.Item1);
                    s.Append("=@");
                    s.Append(item.Item1);
                    Count++;
                }
            }
            return s.ToString();
        }
        public static string InsertIntoStatement(DataTable _dtTableColumns, string DataBase, string TableName)
        {
            if (_dtTableColumns == null || string.IsNullOrEmpty(DataBase) || string.IsNullOrEmpty(TableName))
                return "Insert Into";
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBase);
            StringBuilder s = new StringBuilder();
            s.Append("INSERT INTO " + TableName + " (");
            for (int i = 0; i < _dtTableColumns.Rows.Count; i++)
            {
                if (_dtTableColumns.Rows[i][0].ToString() == PrimaryKey)
                    continue;
                s.Append(_dtTableColumns.Rows[i][0].ToString());
                s.Append(",");
            }
            s.Length--;
            s.Append(") VALUES(");
            for (int i = 0; i < _dtTableColumns.Rows.Count; i++)
            {
                if (_dtTableColumns.Rows[i][0].ToString() == PrimaryKey)
                    continue;
                s.Append("@");
                s.Append(_dtTableColumns.Rows[i][0].ToString());
                s.Append(",");
            }
            s.Length--;
            s.Append(");SELECT SCOPE_IDENTITY();");
            return s.ToString();
        }
        public static string UpdateStatement(List<Tuple<string, string>> vSelectedColumns, List<Tuple<string, string>> vWhereItemsWithDataTypes, string TableName, string DataBaseName)
        {
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBaseName);
            StringBuilder s = new StringBuilder();
            s.Append("UPDATE ");
            s.Append(TableName);
            s.Append(" Set ");
            foreach (var Item in vSelectedColumns)
            {
                if (Item.Item1== PrimaryKey)
                    continue;
                s.Append(Item.Item1 + "=@" + Item.Item1 + " ,");
            }
            s.Length--;
            if (vWhereItemsWithDataTypes.Count <= 0)
                return s.ToString();
            s.Append(" Where ");
            int Count = 0;
            foreach(var Item in vWhereItemsWithDataTypes)
            {
                if (Count > 0)
                    s.Append(" and ");
                s.Append(Item.Item1 + "=@" + Item.Item1);
                Count++;
            }
            return s.ToString();
        }
        public static string DeletStatement(List<Tuple<string,string>>vWhere, string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("Delete From " + TableName);
            if(vWhere.Count>0)
            {
                s.Append(" Where ");
                int Count = 0;
                foreach (var Item in vWhere)
                {
                    if (Count > 0)
                        s.Append(" and ");
                    s.Append(Item.Item1 + "=@" + Item.Item1);
                    Count++;
                }
            }
            return s.ToString();
        }
        public static string FillReaderStatement(List<Tuple<string, string>> vSelectedColumns,string DataBaseName,string TableName)
        {
            StringBuilder s = new StringBuilder();
            foreach(var Item in vSelectedColumns)
            {
                if (clsDataBase.IsFieldNullable(Item.Item1,DataBaseName,TableName))
                {
                    s.Append("if(reader[" + "\"" + Item.Item1 + "\"" + "]!=DBNull.Value)\n");
                    s.Append(Item.Item1 + "=" + "(" + _GetElementType(Item.Item2) + ")" + "reader[" + "\"" +
                        Item.Item1 + "\"" + "];\n");
                    s.Append("else\n");
                    s.Append(Item.Item1 + "=" + "\"" + "\"" + "\n");
                }
                else
                    s.Append(Item.Item1 + "=" + "(" + _GetElementType(Item.Item2) + ")" + "reader[" + "\"" +
                       Item.Item1 + "\"" + "];\n");
            }
            return s.ToString();
        }
        public static string FillAddWithValueStatements(List<Tuple<string, string>> vSelectedColumns, string TableName,string DataBaseName,
            bool ConditionForInsertOrUpdateFuncions)
        {
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBaseName);
            StringBuilder s = new StringBuilder();
            foreach (var Item in vSelectedColumns)
            {
                if (PrimaryKey == Item.Item1 && ConditionForInsertOrUpdateFuncions)
                    continue;
                else if (clsDataBase.IsFieldNullable(Item.Item1,DataBaseName,TableName))
                {
                    s.Append("if(" + Item.Item1 + "!=" + "\"" + "\"" + " && " +Item.Item1 + "!=null)\n");
                    s.Append("command.Parameters.AddWithValue(@" + Item.Item1 + "," +Item.Item1 + ");\n");
                    s.Append("else\n");
                    s.Append("command.Parameters.AddWithValue(@" + Item.Item1 + "," + "System.DBNull.Value);\n");
                }
                else
                    s.Append("command.Parameters.AddWithValue(@" + Item.Item1 + "," + Item.Item1 + ");\n");
            }
            return s.ToString();
        }
        public static string FillAddWithValueForInsert(DataTable _dtColumns, string DataBaseName,string TableName)
        {
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBaseName);
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < _dtColumns.Rows.Count; i++)
            {
                if (PrimaryKey == _dtColumns.Rows[i][0].ToString())
                    continue;
                else if ((bool)_dtColumns.Rows[i][2] == true)
                {
                    s.Append("if(" + _dtColumns.Rows[i][0] + "!=" + "\"" + "\"" + " && " + _dtColumns.Rows[i][0] + "!=null)\n");
                    s.Append("command.Parameters.AddWithValue(@" + _dtColumns.Rows[i][0] + "," + _dtColumns.Rows[i][0] + ");\n");
                    s.Append("else\n");
                    s.Append("command.Parameters.AddWithValue(@" + _dtColumns.Rows[i][0] + "," + "System.DBNull.Value);\n");
                }
                else
                    s.Append("command.Parameters.AddWithValue(@" + _dtColumns.Rows[i][0] + "," + _dtColumns.Rows[i][0] + ");\n");
            }
            return s.ToString();
        }
        private static string _GetElementType(string DataBaseType)
        {
            switch (DataBaseType)
            {
                case "int":
                    return "int";
                case "tinyint":
                    return "int";
                case "smallint":
                    return "int";
                case "smallmoney":
                    return "float";
                case "float":
                    return "float";
                case "real":
                    return "float";
                case "datetime":
                    return "DateTime";
                case "bit":
                    return "bool";
                case "nchar":
                    return "string";
                case "nvarchar":
                    return "string";
                case "varchar":
                    return "string";
                case "text":
                    return "string";
                default:
                    return "";
            }
        }
        public static string GetAllElements(string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("Select * From " + TableName);
            return s.ToString();
        }
        public static string GetItemPrefix(string Item)
        {
            switch (Item)
            {
                case "TextBox":
                    return "txt";
                case "Label":
                    return "lbl";
                case "CheckBox":
                    return "cb";
                case "DateTimePicker":
                    return "dt";
                case "ComboBox":
                    return "cmb";
                case "PictureBox":
                    return "pb";
                case "DataGridView":
                    return "dgv";
                default:
                    return "";
            }
        }
    }
}

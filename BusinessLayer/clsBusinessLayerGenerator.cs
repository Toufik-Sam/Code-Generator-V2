using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessLayerGenerator
    {
        public static string GenerateClassGetAllItems(string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public static DataTable GetAllItems()\n");
            s.Append("{\n");
            s.Append("return cls" + TableName + "Data.GetAllItems();\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassAddNew(DataTable _dtTableData,string TableName,string DataBaseName)
        {
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBaseName);
            StringBuilder s = new StringBuilder();
            s.Append("public bool _AddNew()\n");
            s.Append("{\n");
            s.Append("this." + PrimaryKey+"="+"cls"+TableName+"Data.AddNew");
            s.Append(clsUtil.AttributesLoopWithThis(_dtTableData, PrimaryKey));
            s.Append("return " + "this." + clsDataBaseInfo.GetTablePrimaryKeyByTableName(TableName, DataBaseName) + "!=-1\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassUpdate(DataTable _dtTableData,string TableName,string DataBaseName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public bool _Update()\n");
            s.Append("{\n");
            s.Append("return cls" + TableName + "Data.Update" + clsUtil.AttributesLoopWithThis(_dtTableData,""));
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassDeleteFunction(string DataBaseName, string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public static bool Delete(" + clsDataBaseInfo.GetTablePrimaryKeyByTableName(TableName, DataBaseName) + ")\n");
            s.Append("{\n");
            s.Append("return cls" + TableName + "Data" + ".Delete(int " + clsDataBaseInfo.GetTablePrimaryKeyByTableName(TableName, DataBaseName) +
                ");\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassFind(List<Tuple<string,string>>vSelect,List<Tuple<string,string>>vWhere,
            string DataBaseName,string TableName)
        {
            StringBuilder s = new StringBuilder();
            string Attributes = clsUtil.AttributesLoop(vWhere);
            s.Append("public static DataTable" + " Find"+Attributes+"\n");
            s.Append("{\n");
            if (vSelect != null)
                s.Append("return cls" + TableName + "Data.GetItemsInfoByKeys" + Attributes + ";\n");
            else
                s.Append("return cls" + TableName + "Data.GetItemsInfoByKeys()\n");
            s.Append("}\n");
            return s.ToString();
        }
        
    }
}

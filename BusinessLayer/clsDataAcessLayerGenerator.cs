using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDataAcessLayerGenerator
    {
        public static string GenerateClassDataGetItemsInfoByKeys(string DataBaseName,string TableName, 
            List<Tuple<string, string>> vSelectedItemsWithDataTypes, List<Tuple<string, string>> vWhereItemsWithDataTypes)
        {
            bool Condition = (vWhereItemsWithDataTypes.Count > 0);
            StringBuilder s = new StringBuilder();

            if (vWhereItemsWithDataTypes != null)
            {
                string Attributes = clsUtil.AttributesLoop(vWhereItemsWithDataTypes);
                s.Append("public static DataTable GetItemsInfoByKeys" + Attributes + "\n");
            }
            else
                s.Append("public static DataTable GetItemsInfoByKeys()"+"\n");
            s.Append("{\n");
            s.Append("bool isFound=false;\n");
            s.Append("string ConnectionString= "+ "\"" + clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName)+ "\"" + ";"+"\n");
            s.Append("using(sqlconnection connection=new sqlconnection(ConnectionString))\n");
            s.Append("{\n");
            s.Append("connection.Open();\n");
            s.Append("string query= "+ "\"" + clsUtil.SelectItemsStatment(vSelectedItemsWithDataTypes,vWhereItemsWithDataTypes,
                TableName,Condition)+ "\""+";\n");
            s.Append("using(sqlcommand command=new sqlcommand(query,connection))\n");
            s.Append("{\n");
            if(vWhereItemsWithDataTypes!=null)
                s.Append(clsUtil.FillAddWithValueStatements(vWhereItemsWithDataTypes, TableName, DataBaseName, false));
            s.Append("using(sqlReader reader=command.ExecuteReader())\n");
            s.Append("{\n");
            s.Append("if(reader.HasRows)\n");
            s.Append("dt.load(reader)");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("return dt;\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassDataAddNew(DataTable _dtColumn,string DataBaseName, string TableName)
        {
            StringBuilder s = new StringBuilder();
            string PrimaryKey = clsDataBase.GetTablePrimaryKeyByName(TableName, DataBaseName);
            s.AppendLine("public static int AddNew" + clsUtil.AttributesLoop(_dtColumn,PrimaryKey));
            s.Append("{\n");
            s.Append("int ID=-1\n");
            s.Append("string ConnectionString= " +"\"" +clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName)+"\";"+ "\n");
            s.Append("using(sqlconnection connection=new sqlconnection(ConnectionString))\n");
            s.Append("{\n");
            s.Append("connection.Open();\n");
            s.Append("string query=" + "\"" + clsUtil.InsertIntoStatement(_dtColumn, DataBaseName, TableName)+ "\";\n");
            s.Append("using(sqlcommand command=new sqlcommand(query,connection))\n");
            s.Append("{\n");
            s.Append(clsUtil.FillAddWithValueForInsert(_dtColumn,DataBaseName,TableName));
            s.Append("object result=command.ExecuteScalar();\n");
            s.Append("if(result!=null && int.TryParse(result.ToString(),out int InsertedID))\n");
            s.Append("ID=InsertedID;\n");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("return ID\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassDataUpdate(List<Tuple<string, string>> vSelectedItemsWithDataTypes, List<Tuple<string, string>> vWhereItemsWithDataTypes,string DataBaseName, string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public static bool Update" + clsUtil.AttributesLoop(vSelectedItemsWithDataTypes,vWhereItemsWithDataTypes));
            s.Append("{\n");
            s.Append("int rowsAffected=0;\n");
            s.Append("string ConnectionString= " + "\"" + clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName) + "\"" + ";" + "\n");
            s.Append("using(sqlconnection connection=new sqlconnection(ConnectionString))\n");
            s.Append("{\n");
            s.Append("connection.Open();\n");
            s.Append("string query= " + "\"" + clsUtil.UpdateStatement(vSelectedItemsWithDataTypes,vWhereItemsWithDataTypes,TableName,DataBaseName)+"\";\n");
            s.Append("using(sqlcommand=new sqlcommand(query,connection))\n");
            s.Append("{\n");
            s.Append(clsUtil.FillAddWithValueStatements(vWhereItemsWithDataTypes, TableName, DataBaseName,false));
            s.Append(clsUtil.FillAddWithValueStatements(vSelectedItemsWithDataTypes, TableName, DataBaseName,true));
            s.Append("rowsAffected=command.ExecuteNonQuery();\n");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("return rowsAffected>0;\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassDataDelete(List<Tuple<string, string>> vWhereItemsWithDataTypes,string DataBaseName, string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public static bool Delete"+clsUtil.AttributesLoop(vWhereItemsWithDataTypes));
            s.Append("{\n");
            s.Append("int rowsAffected=0;\n");
            s.Append("string ConnectionString= " + "\"" + clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName) + "\"" +";"+ "\n");
            s.Append("using(sqlconnection connection=new sqlconnection(ConnectionString))\n");
            s.Append("{\n");
            s.Append("connection.Open();\n");
            s.Append("string query=" + "\"" + clsUtil.DeletStatement(vWhereItemsWithDataTypes,TableName)+"\";\n");
            s.Append("using(sqlcommand=new sqlcommand(query,connection))\n");
            s.Append("{\n");
            s.Append(clsUtil.FillAddWithValueStatements(vWhereItemsWithDataTypes, TableName, DataBaseName,false));
            s.Append("rowsAffected=command.ExecuteNonQuery();\n");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("return rowsAffected>0;\n");
            s.Append("}\n");
            return s.ToString();
        }
        public static string GenerateClassGetAllItems(string DataBaseName,string TableName)
        {
            StringBuilder s = new StringBuilder();
            s.Append("public static DataTable GetAllItems()\n");
            s.Append("{\n");
            s.Append("DataTable dt=new DataTable();\n");
            s.Append("string ConnectionString=" + "\"" + clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName) + "\"" + ";\n");
            s.Append("using(sqlconnection connection=new sqlconnection(ConnectionString))\n");
            s.Append("{\n");
            s.Append("connection.Open();\n");
            s.Append("string query="+"\""+clsUtil.GetAllElements(TableName)+"\""+";\n");
            s.Append("using(sqlcommand=new sqlcommand(query,connection))\n");
            s.Append("{\n");
            s.Append("using(sqlReader reader=command.ExecuteReader())\n");
            s.Append("{\n");
            s.Append("if(reader.HasRows)\n");
            s.Append("dt.load(reader)");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("}\n");
            s.Append("return dt;\n");
            s.Append("}\n");
            return s.ToString();

        }
    }
}

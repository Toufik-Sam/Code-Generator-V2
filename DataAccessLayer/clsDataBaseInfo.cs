using System;

using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class clsDataBaseInfo
    {
        public static DataTable GetAllServerDataBaseNames()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases Where name!='master' and name!='tempdb' and name!='model' and name!='msdb'", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                            dt.Load(dr);
                    }
                }
            }
            return dt;
        }
        public static DataTable GetAllTablesListByDataBaseName(string DataBaseName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName)))
            {
                connection.Open();
                string query = "select name from sys.Tables Where sys.tables.name!='sysdiagrams'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;

        }
        public static DataTable GetAllColumnsByTableName(string TableName, string DataBaseName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.
                GetDataBaseConnectionStringByName(DataBaseName)))
            {
                connection.Open();
                string query = "select sys.columns.name as COLUMN_NAME,sys.types.name as DATA_TYPE,sys.Columns.is_nullable from sys.types Inner Join sys.columns on sys.columns.system_type_id=sys.types.system_type_id Where sys.Columns.object_id=(select object_id from sys.Tables Where name=@TableName)and sys.types.name!='sysname'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", TableName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;
        }
        public static string GetTablePrimaryKeyByTableName(string TableName, string DataBaseName)
        {
            string ColumnName = "";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.
                GetDataBaseConnectionStringByName(DataBaseName)))
            {
                connection.Open();
                string query = "select C.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS T JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE C ON C.CONSTRAINT_NAME=T.CONSTRAINT_NAME WHERE C.TABLE_NAME=@TableName and T.CONSTRAINT_TYPE='PRIMARY KEY'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", TableName);
                    object result = command.ExecuteScalar();
                    if (result != null)
                        ColumnName = result.ToString();
                }
            }
            return ColumnName;
        }
        public static bool IsFieldNullable(string FiledName,string DataBaseName,string TableName)
        {
            bool IsNullable = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.
                GetDataBaseConnectionStringByName(DataBaseName)))
            {
                connection.Open();
                string query = "select sys.Columns.is_nullable from  sys.columns Where sys.Columns.object_id=(select object_id from sys.Tables Where name=@TableName and sys.Columns.name=@FieldName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableName", TableName);
                    command.Parameters.AddWithValue("@FieldName", FiledName);
                    IsNullable =(bool) command.ExecuteScalar();
                }
            }
            return IsNullable;
        }
    }
}

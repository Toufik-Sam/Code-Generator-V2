using DataAccessLayer;
using System.Data;
namespace BusinessLayer
{
    public class clsDataBase
    {
        public static DataTable GetAllDataBaseNames()
        {
            return clsDataBaseInfo.GetAllServerDataBaseNames();
        }
        public static DataTable GetAllTablesByDataBaseName(string DataBaseName)
        {
            return clsDataBaseInfo.GetAllTablesListByDataBaseName(DataBaseName);
        }
        public static DataTable GetAllColumnByTableName(string TableName, string DataBaseName)
        {
            return clsDataBaseInfo.GetAllColumnsByTableName(TableName, DataBaseName);
        }
        public static string GetTablePrimaryKeyByName(string TableName, string DataBaseName)
        {
            return clsDataBaseInfo.GetTablePrimaryKeyByTableName(TableName, DataBaseName);
        }
        public static string GetDataBaseConnectionString(string DataBaseName)
        {
            return clsDataAccessSettings.GetDataBaseConnectionStringByName(DataBaseName);
        }
        public static bool IsFieldNullable(string FieldName,string DataBaseName,string TableName)
        {
            return clsDataBaseInfo.IsFieldNullable(FieldName, DataBaseName, TableName);
        }
        public static bool ValidateDatabaseAccessSettings(string DataBaseName,string UserID,string Password)
        {
            return clsDataAccessSettings.ValidateDatabaseAccessSettings(DataBaseName,UserID, Password);
        }
        public static bool IsConnectivityAvailable(string DataBaseName)
        {
            return clsDataAccessSettings.IsConnectionAvailable(DataBaseName);
        }

    }
}

using System;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = "Data Source=.; Integrated Security=True;";
        public static string UserID { set; private get; }
        public static string Password { set; private get; }
        //sa
        //sa123456
        public static string GetDataBaseConnectionStringByName(string DataBaseName)
        {
            return "Server=.;Database=" + DataBaseName + ";User Id="+ UserID + ";Password="+Password;
        }
        public static bool ValidateDatabaseAccessSettings(string DataBaseName,string UserID,string Password)
        {
            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(Password))
                return false;
            clsDataAccessSettings.UserID = UserID;
            clsDataAccessSettings.Password = Password;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetDataBaseConnectionStringByName(DataBaseName)))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool IsConnectionAvailable(string DataBaseName)
        {
            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(Password))
                return false;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetDataBaseConnectionStringByName(DataBaseName)))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

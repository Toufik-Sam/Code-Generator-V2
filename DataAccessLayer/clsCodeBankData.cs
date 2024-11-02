using System;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class clsCodeBankData
    {
        public static int AddNewCodeToBank(string CodeTitle,string MainCode)
        {
            int InsertedID = -1;
            using(SqlConnection connection=new SqlConnection(clsDataAccessSettings.GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                using(SqlCommand command=new SqlCommand("SP_AddNewCode",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodeTitle", SqlDbType.VarChar).Value = CodeTitle;
                    command.Parameters.AddWithValue("@Code", SqlDbType.VarChar).Value = MainCode;
                    SqlParameter OutputIDParam = new SqlParameter("@NewAddedCodeID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(OutputIDParam);
                    connection.Open();
                    command.ExecuteNonQuery();
                    InsertedID = (int)command.Parameters["@NewAddedCodeID"].Value;
                }
            }
            return InsertedID;
        }
        public static bool UpdateCodeInBank(int CodeID,string CodeTitle,string MainCode)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.
                GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateCode", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodeID", SqlDbType.Int).Value = CodeID;
                    command.Parameters.AddWithValue("@CodeTitle", SqlDbType.VarChar).Value = CodeTitle;
                    command.Parameters.AddWithValue("@Code", SqlDbType.VarChar).Value = MainCode;
                    connection.Open();
                    rowsAffected=(int)command.ExecuteNonQuery();
                }
            }
            return rowsAffected>0;
        }
        public static bool DeleteCodeInBank(int CodeID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.
                GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteCode", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodeID", SqlDbType.Int).Value = CodeID;
                    connection.Open();
                    rowsAffected = (int)command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
        public static bool GetCodeInfoByID(int CodeID,ref string CodeTitle,ref string MainCode)
        {
            bool IsFound = false;
            using(SqlConnection connection=new SqlConnection(clsDataAccessSettings
                .GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                using(SqlCommand command=new SqlCommand("SP_GetCodeInfoByID",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodeID", SqlDbType.Int).Value = CodeID;
                    connection.Open();
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            CodeTitle = (string)reader["CodeTitle"];
                            MainCode = (string)reader["Code"];
                            IsFound = true;
                        }
                    }
                }
            }
            return IsFound;
        }
        public static DataTable SearchForCodes(string FilterValue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings
                       .GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                string query = "Select * From dbo.SearchForCodeByTitle(@FilterValue)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilterValue", SqlDbType.VarChar).Value = FilterValue;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;

        }
        public static DataTable GetTopTenCodes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings
                    .GetDataBaseConnectionStringByName("CodeGeneratorDB")))
            {
                string query = "Select top 10 * From CodeBank";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }
            return dt;

        }       
    }
}

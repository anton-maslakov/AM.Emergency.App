using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class RescuersRepository : IRescuersRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RescuersRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }
        public IEnumerable<RescuerModel> GetAllData()
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRescuesrs", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rescuerList.Add(new RescuerModel
                    {
                        Id = reader.GetInt32(1),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        BirthDate = reader[5].ToString(),
                        Job = reader.GetString(6)

                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return rescuerList;
        }

        public IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber)
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetBrigadeRescuers", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@BrigadeNumber", brigadeNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rescuerList.Add(new RescuerModel
                    {
                        Id = reader.GetInt32(1),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        BirthDate = reader[5].ToString(),
                        Job = reader.GetString(6)

                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return rescuerList;
        }
    }
}

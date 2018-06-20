using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class CasualtyRepository : ICasualtyRepository
    {
        private static ILogger _logger;
        private string _conn;
        public CasualtyRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber)
        {
            List<CasualtyModel> casualtyList = new List<CasualtyModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetCasualtyByRequest", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    casualtyList.Add(new CasualtyModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        BirthDate = reader[5].ToString(),
                        Address = reader.GetString(6)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return casualtyList;
        }
    }
}

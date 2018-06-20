using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository
{
    public class RescuersManipulator : IDataManipulator<RescuerModel>
    {
        private static ILogger _logger;
        private string _conn;
        public RescuersManipulator(string conn, ILogger logger)
        {
            _logger = logger;
            _conn = conn;
        }
        public IEnumerable<RescuerModel> GetData(string sqlInjection)
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    _logger.Log(LogLevel.Info, "Database connection success");
                }
                catch (SqlException ex)
                {
                    _logger.Log(LogLevel.Error, ex.Message);
                }
                SqlCommand sqlCommand = new SqlCommand(sqlInjection, conn);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rescuerList.Add(new RescuerModel
                            {
                                Id = reader.GetInt32(0),
                                Name=reader.GetString(1),
                                Surname=reader.GetString(2),
                                LastName=reader.GetString(3),
                                BirthDate=reader.GetDateTime(4),
                                Job=reader.GetString(5),
                            });
                        }
                    }
                }
            }
            return rescuerList;
        }
    }
}

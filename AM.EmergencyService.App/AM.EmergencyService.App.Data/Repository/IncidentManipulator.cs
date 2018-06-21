using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository
{
    public class IncidentManipulator:IDataManipulator<IncidentModel>
    {
        private static ILogger _logger;
        private string _conn;
        public IncidentManipulator(string conn, ILogger logger)
        {
            _logger = logger;
            _conn = conn;
        }

        public IEnumerable<IncidentModel> GetData(string sqlInjection)
        {
            List<IncidentModel> incidentList = new List<IncidentModel>();
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

                            incidentList.Add(new IncidentModel
                            {
                                Id = reader.GetInt32(0),
                                IncidentInformation = reader.GetString(1),
                                IncidentReason=reader.GetString(2),
                                IdRequest=reader.GetInt32(3)
                            });
                        }
                    }

                }
            }
            return incidentList;
        }
    }
}

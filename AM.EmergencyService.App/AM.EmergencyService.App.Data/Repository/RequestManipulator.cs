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
    class RequestManipulator : IDataManipulator<RequestModel>
    {
        private static ILogger _logger;
        private string _conn;
        public RequestManipulator(string conn, ILogger logger)
        {
            _logger = logger;
            _conn = conn;
        }
        public IEnumerable<RequestModel> GetData(string sqlInjection)
        {
            List<RequestModel> requestList = new List<RequestModel>();
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
                            requestList.Add(new RequestModel
                            {
                                Id = reader.GetInt32(0),
                                RequestNumber=reader.GetInt32(1),
                                RequestCategory = reader.GetString(9),
                                RequestAddress =reader.GetString(2),
                                RequestReason=reader.GetString(3),
                                RequestDate=reader.GetDateTime(4),
                                BrigadeCallDate=reader.GetDateTime(5),
                                BrigadeArrivalDate=reader.GetDateTime(6),
                                BrigadeEndDate=reader.GetDateTime(7),
                                BrigadeReturnDate=reader.GetDateTime(8),
                                idBrigade=reader.GetInt32(10)
                            });
                        }
                    }
                }
            }
            return requestList;
        }
    }
}

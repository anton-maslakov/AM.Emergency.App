using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    class RequestsRepository : IRequestsRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RequestsRepository(ILogger logger)
        {
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }
        public IEnumerable<RequestModel> GetAllData()
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequests", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader[3].ToString(),
                        CategoryName = reader.GetString(4)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestList;
        }
    }
}

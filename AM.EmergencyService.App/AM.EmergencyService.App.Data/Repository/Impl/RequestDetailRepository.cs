using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class RequestDetailRepository:IRequestDetailsRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RequestDetailRepository(ILogger logger)
        {
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public IEnumerable<RequestDetailModel> GetRequestDetailsByRequestNumber(int requestNumber)
        {
            List<RequestDetailModel> requestDetailList = new List<RequestDetailModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestDetails", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    requestDetailList.Add(new RequestDetailModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        IncidentInformation=reader.GetString(1),
                        IncidentReason=reader.GetString(2),
                        BrigadeNumber=reader.GetInt32(3),
                        BrigadeCallDate=reader[4].ToString(),
                        BrigadeArrivalDate=reader[5].ToString(),
                        BrigadeEndDate=reader[6].ToString(),
                        BrigadeReturnDate=reader[7].ToString()
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestDetailList;
        }
    }
}

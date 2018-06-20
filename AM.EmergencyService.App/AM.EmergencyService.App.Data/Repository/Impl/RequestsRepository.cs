using AM.EmergencyService.App.Common.Helper;
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
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
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

        public IEnumerable<RequestModel> GetRequestByAddress(string requestAddress)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestByAddress", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestAddress", requestAddress);
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

        public IEnumerable<RequestModel> GetRequestByCategory(string requestCategory)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestByCategory", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestCategory", requestCategory);
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

        public IEnumerable<RequestModel> GetRequestByNumber(int requestNumber)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestByNumber", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
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

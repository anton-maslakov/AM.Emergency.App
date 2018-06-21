using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public void Create(RequestModel requestModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertRequest", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestAddress", Value = requestModel.RequestAddress},
                    new SqlParameter() { ParameterName = "@RequestReason", Value = requestModel.RequestReason},
                    new SqlParameter() { ParameterName = "@IdCategory", Value = requestModel.Category.Id}
                };

                command.Parameters.AddRange(sqlParameters);

                command.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
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
            SqlCommand command = new SqlCommand("GetRequestByAddress", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@RequestAddress", requestAddress);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestList;
        }

        public IEnumerable<RequestModel> GetRequestByAddressAndDate(string requestAddress, string requestDate)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetRequestByAddressAndDate", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestAddress", Value = requestAddress},
                    new SqlParameter() { ParameterName = "@RequestDate", Value = requestDate}
                };
                command.Parameters.AddRange(sqlParameters);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
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
            SqlCommand command = new SqlCommand("GetRequestByCategory", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@RequestCategory", requestCategory);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestList;
        }

        public IEnumerable<RequestModel> GetRequestByCategoryAndDate(string requestCategory, string requestDate)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetRequestByCategoryAndDate", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestCategory", Value = requestCategory},
                    new SqlParameter() { ParameterName = "@RequestDate", Value = requestDate}
                };
                command.Parameters.AddRange(sqlParameters);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
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
            SqlCommand command = new SqlCommand("GetRequestByNumber", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = new CategoryModel { CategoryName = reader.GetString(4) }
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestList;
        }

        public IEnumerable<RequestModel> GetRequestByNumberAndDate(int requestNumber, string requestDate)
        {
            List<RequestModel> requestList = new List<RequestModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetRequestByNumberAndDate", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestNumber},
                    new SqlParameter() { ParameterName = "@RequestDate", Value = requestDate}
                };
                command.Parameters.AddRange(sqlParameters);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new RequestModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        RequestAddress = reader.GetString(1),
                        RequestReason = reader.GetString(2),
                        RequestDate = reader.GetDateTime(3),
                        Category = { CategoryName = reader.GetString(4) }
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestList;
        }

        public void Update(RequestModel requestModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("UpdateRequest", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestModel.RequestNumber},
                    new SqlParameter() { ParameterName = "@RequestAddress", Value = requestModel.RequestAddress},
                    new SqlParameter() { ParameterName = "@RequestReason", Value = requestModel.RequestReason},
                    new SqlParameter() { ParameterName = "@RequestDate", Value = requestModel.RequestDate},
                    new SqlParameter() { ParameterName = "@IdCategory", Value = requestModel.Category.Id}
                };

                command.Parameters.AddRange(sqlParameters);

                command.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }
    }
}

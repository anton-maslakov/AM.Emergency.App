using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class InventoryRepository : IInventoryRepository
    {
        private static ILogger _logger;
        private string _conn;
        public InventoryRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void Create(InventoryModel inventoryModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertInventory", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@InventoryName", Value = inventoryModel.InventoryName},
                    new SqlParameter() { ParameterName = "@InventoryNumber", Value = inventoryModel.InventoryNumber}
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<InventoryModel> GetAllData()
        {
            List<InventoryModel> inventoryList = new List<InventoryModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetInventory", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    inventoryList.Add(new InventoryModel
                    {
                        InventoryNumber = reader.GetInt32(0),
                        InventoryName = reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return inventoryList;
        }

        public IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber)
        {
            List<InventoryModel> inventoryList = new List<InventoryModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestInventory", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    inventoryList.Add(new InventoryModel
                    {
                        InventoryNumber = reader.GetInt32(0),
                        InventoryName = reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return inventoryList;
        }

        public void Update(InventoryModel inventoryModel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InventoryModel> GetInventoryByBrigadeNumber(int brigadeNumber)
        {
            List<InventoryModel> inventoryList = new List<InventoryModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetBrigadeInventory", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@BrigadeNumber", brigadeNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    inventoryList.Add(new InventoryModel
                    {
                        InventoryNumber = reader.GetInt32(0),
                        InventoryName = reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return inventoryList;
        }

        public void DeleteInventoryFromBrigade(int brigadeNumber, int inventoryNumber)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("DeleteInventoryFromBrigade", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@BrigadeNumber", Value = brigadeNumber},
                    new SqlParameter() { ParameterName = "@InventoryNumber", Value = inventoryNumber}
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

        public void DeleteInventoryFromRequest(int requestNumber, int inventoryNumber)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("DeleteInventoryFromRequest", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestNumber},
                    new SqlParameter() { ParameterName = "@InventoryNumber", Value = inventoryNumber}
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

        public IEnumerable<InventoryModel> GetInventoryNotInRequest(int requestNumber)
        {
            List<InventoryModel> inventoryList = new List<InventoryModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetInventoryNotInRequest", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    inventoryList.Add(new InventoryModel
                    {
                        InventoryNumber = reader.GetInt32(0),
                        InventoryName = reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return inventoryList;
        }
    }
}


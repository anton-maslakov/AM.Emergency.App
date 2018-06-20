using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class BrigadesRepository : IBrigadesRepository
    {
        private static ILogger _logger;
        private string _conn;
        public BrigadesRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void Add(BrigadeModel brigadeModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertBrigades", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@BrigadeNumber", brigadeModel.BrigadeNumber);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public IEnumerable<BrigadeModel> GetAllData()
        {
            List<BrigadeModel> brigadeList = new List<BrigadeModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetBrigades", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brigadeList.Add(new BrigadeModel
                    {
                        BrigadeNumber = reader.GetInt32(0)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return brigadeList;
        }

        public void AddRescuersBrigade(int brigadeNumber, int rescuerId)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertRescuersBrigades", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@BrigadeNumber", Value = brigadeNumber},
                    new SqlParameter() { ParameterName = "@IdRescuers", Value = rescuerId}
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

        public void AddInventoryBrigade(int brigadeNumber, int inventoryNumber)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertBrigadesInventory", conn) { CommandType = CommandType.StoredProcedure };

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

        public IEnumerable<BrigadeModel> GetBrigadeByDate(DateTime date)
        {
            List<BrigadeModel> brigadeList = new List<BrigadeModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetBrigadeByDate", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@Date", date);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brigadeList.Add(new BrigadeModel
                    {
                        BrigadeNumber = reader.GetInt32(0)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return brigadeList;
        }
    }
}

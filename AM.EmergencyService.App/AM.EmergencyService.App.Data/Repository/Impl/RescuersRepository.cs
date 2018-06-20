using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class RescuersRepository : IRescuersRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RescuersRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void Create(RescuerModel rescuerModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertRescuers", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@FirstName", Value = rescuerModel.Firstname},
                    new SqlParameter() { ParameterName = "@Surname", Value = rescuerModel.Surname},
                    new SqlParameter() { ParameterName = "@Lastname", Value = rescuerModel.Lastname},
                    new SqlParameter() { ParameterName = "@BirthDate", Value = rescuerModel.BirthDate.ToShortDateString()},
                    new SqlParameter() { ParameterName = "@Job", Value = rescuerModel.Job}
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

        public IEnumerable<RescuerModel> GetAllData()
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRescuers", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rescuerList.Add(new RescuerModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Job = reader.GetString(5)

                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return rescuerList;
        }

        public IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber)
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetBrigadeRescuers", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@BrigadeNumber", brigadeNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rescuerList.Add(new RescuerModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Job = reader.GetString(5)

                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return rescuerList;
        }

        public IEnumerable<RescuerModel> GetRescuersNotInBrigade()
        {
            List<RescuerModel> rescuerList = new List<RescuerModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRescuersNotInBrigade", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    rescuerList.Add(new RescuerModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Job = reader.GetString(5)

                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return rescuerList;

        }

        public void Update(RescuerModel rescuerModel)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("DeleteRescuerFromBrigade", conn) { CommandType = CommandType.StoredProcedure };

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
    }
}

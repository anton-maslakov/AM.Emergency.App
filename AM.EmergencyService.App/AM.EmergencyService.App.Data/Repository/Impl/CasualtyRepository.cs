using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class CasualtyRepository : ICasualtyRepository
    {
        private static ILogger _logger;
        private string _conn;
        public CasualtyRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void Create(CasualtyModel casualtyModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertCasualty", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@FirstName", Value = casualtyModel.Firstname},
                    new SqlParameter() { ParameterName = "@Surname", Value = casualtyModel.Surname},
                    new SqlParameter() { ParameterName = "@Lastname", Value = casualtyModel.Lastname},
                    new SqlParameter() { ParameterName = "@BirthDate", Value = casualtyModel.BirthDate.ToShortDateString()},
                    new SqlParameter() { ParameterName = "@Address", Value = casualtyModel.Address}
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

        public void DeleteCasualtyFromRequest(int requestNumber, int casualtyId)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("DeleteCasualtyFromRequest", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestNumber},
                    new SqlParameter() { ParameterName = "@CasualtyId", Value = casualtyId}
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

        public IEnumerable<CasualtyModel> GetAllCasualty()
        {
            List<CasualtyModel> casualtyList = new List<CasualtyModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetAllCasualty", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    casualtyList.Add(new CasualtyModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname=reader.GetString(2),
                        Lastname=reader.GetString(3),
                        BirthDate=reader.GetDateTime(4),
                        Address=reader.GetString(5)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return casualtyList;
        }

        public CasualtyModel GetCasualtyById(int casualtyId)
        {
            CasualtyModel casualty = new CasualtyModel();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetCasualtyById", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", casualtyId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    casualty = new CasualtyModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Address = reader.GetString(5)
                    };
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return casualty;
        }

        public IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber)
        {
            List<CasualtyModel> casualtyList = new List<CasualtyModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetCasualtyByRequest", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    casualtyList.Add(new CasualtyModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return casualtyList;
        }

        public IEnumerable<CasualtyModel> GetCasualtyNotInRequest(int requestNumber)
        {
            List<CasualtyModel> casualtyList = new List<CasualtyModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetCasualtyNotInRequest", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    casualtyList.Add(new CasualtyModel
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return casualtyList;
        }

        public void Edit(CasualtyModel casualtyModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("UpdateCasualty", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@Id", Value = casualtyModel.Id},
                    new SqlParameter() { ParameterName = "@Firstname", Value = casualtyModel.Firstname},
                    new SqlParameter() { ParameterName = "@Surname", Value = casualtyModel.Surname},
                    new SqlParameter() { ParameterName = "@Lastname", Value = casualtyModel.Lastname},
                    new SqlParameter() { ParameterName = "@Address", Value = casualtyModel.Address},
                    new SqlParameter() { ParameterName = "@Birthdate", Value = casualtyModel.BirthDate}
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

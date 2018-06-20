using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models.Authorization;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private static ILogger _logger;
        private string _conn;
        public UserRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void Create(UserModel userModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertUser", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@Login", Value = userModel.Name},
                    new SqlParameter() { ParameterName = "@Password", Value = userModel.Password},
                    new SqlParameter() { ParameterName = "@Email", Value = userModel.Email},
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
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("DeleteUser", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }

        public List<string> GetAllLogins()
        {
            List<string> loginList = new List<string>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetAllLogins", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    loginList.Add(reader.GetString(0));
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return loginList;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            List<UserModel> userList = new List<UserModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetAllUsers", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userList.Add(new UserModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(3)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return userList;
        }

        public UserModel GetUserById(int id)
        {
            UserModel user = new UserModel();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetUserById", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    user = new UserModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Password = reader.GetString(2),
                        Roles = GetUserRoles(reader.GetInt32(0))
                    };
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return user;
        }

        public UserModel GetUserByLogin(string login)
        {
            UserModel user = new UserModel();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetUserByLogin", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@login", login);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    user = new UserModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Password = reader.GetString(2),
                        Roles = GetUserRoles(reader.GetInt32(0))
                    };
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return user;
        }
        public IEnumerable<RoleModel> GetUserRoles(int userId)
        {
            List<RoleModel> roleList = new List<RoleModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetUserRoles", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    roleList.Add(new RoleModel
                    {
                        Rolename = reader.GetString(0)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return roleList;
        }

        public void Update(UserModel userModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("UpdateUser", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@Id", Value = userModel.Id},
                    new SqlParameter() { ParameterName = "@Login", Value = userModel.Name},
                    new SqlParameter() { ParameterName = "@Password", Value = userModel.Password},
                    new SqlParameter() { ParameterName = "@Email", Value = userModel.Email},
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

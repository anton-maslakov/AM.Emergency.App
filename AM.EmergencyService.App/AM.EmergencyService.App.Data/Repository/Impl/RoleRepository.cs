using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models.Authorization;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class RoleRepository : IRoleRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RoleRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            List<RoleModel> roles = new List<RoleModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetAllRoles", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(new RoleModel
                    {
                        Id=reader.GetInt32(0),
                        Rolename=reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return roles;
        }

        public IEnumerable<RoleModel> GetRoleById(int id)
        {
            List<RoleModel> roleList = new List<RoleModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRoleById", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    roleList.Add(new RoleModel
                    {
                        Id = reader.GetInt32(0),
                        Rolename=reader.GetString(1)
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return roleList;
        }

        public IEnumerable<string> GetUserRoles(int id)
        {
            List<string> roles = new List<string>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("GetUserRoles", conn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@UserId", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(reader.GetString(0));
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return roles;
        }
    }
}

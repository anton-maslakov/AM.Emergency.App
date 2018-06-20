using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber)
        {
            List<InventoryModel> brigadeList = new List<InventoryModel>();
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
                    brigadeList.Add(new InventoryModel
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
            return brigadeList;
        }
    }
}

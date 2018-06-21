using System.Collections.Generic;
using System.Data.SqlClient;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository
{
    public class InventoryManipulator : IDataManipulator<InventoryModel>
    {
        private static ILogger _logger;
        private string _conn;
        public InventoryManipulator(string conn, ILogger logger)
        {
            _logger = logger;
            _conn = conn;
        }
        public IEnumerable<InventoryModel> GetData(string sqlInjection)
        {
            List<InventoryModel> inventoryList = new List<InventoryModel>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                try
                {
                    conn.Open();
                    _logger.Log(LogLevel.Info, "Database connection success");
                }
                catch (SqlException ex)
                {
                    _logger.Log(LogLevel.Error, ex.Message);
                }
                SqlCommand sqlCommand = new SqlCommand(sqlInjection, conn);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            inventoryList.Add(new InventoryModel
                            {
                                Id = reader.GetInt32(0),
                                InventoryNumber = reader.GetInt32(1),
                                InventoryName = reader.GetString(2),
                                IdBrigade = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return inventoryList;
        }
        //public IEnumerable<InventoryModel> GetData(int idBrigade)
        //{
        //    List<InventoryModel> inventoryList = new List<InventoryModel>();
        //    using (SqlConnection conn = new SqlConnection(_conn))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            _logger.Log(LogLevel.Info, "Database connection success");
        //        }
        //        catch (SqlException ex)
        //        {
        //            _logger.Log(LogLevel.Error, ex.Message);
        //        }
        //        SqlCommand sqlCommand = new SqlCommand("EXEC GetBrogadeInventory @IdBrigade=" + idBrigade, conn);
        //        using (SqlDataReader reader = sqlCommand.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    inventoryList.Add(new InventoryModel
        //                    {
        //                        Id = reader.GetInt32(0),
        //                        InventoryNumber = reader.GetInt32(1),
        //                        InventoryName = reader.GetString(2),
        //                        IdBrigade = reader.GetInt32(3)
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return inventoryList;
        //}
    }
}

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
    public class BrigadesRepository : IBrigadesRepository
    {
        private static ILogger _logger;
        private string _conn;
        public BrigadesRepository(ILogger logger)
        {
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public IEnumerable<BrigadeModel> GetAllData()
        {
            List<BrigadeModel> brigadeList = new List<BrigadeModel>();
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetBrigades", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
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

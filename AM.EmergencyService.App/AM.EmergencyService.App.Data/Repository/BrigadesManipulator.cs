using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository
{
    public class BrigadesManipulator : IDataManipulator<BrigadeModel>
    {
        private static ILogger _logger;
        private string _conn;
        public BrigadesManipulator(string conn, ILogger logger)
        {
            _logger = logger;
            _conn = conn;
        }

        public IEnumerable<BrigadeModel> GetData(string sqlInjection)
        {
            List<BrigadeModel> brigadeList = new List<BrigadeModel>();
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

                            brigadeList.Add(new BrigadeModel
                            {
                                Id = reader.GetInt32(0),
                                BrigadeNumber = reader.GetInt32(1)
                            });
                        }
                    }

                }
            }
            return brigadeList;
        }
    }
}

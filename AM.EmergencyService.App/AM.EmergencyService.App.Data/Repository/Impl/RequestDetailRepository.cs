using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using System.Data;
using System.Data.SqlClient;

namespace AM.EmergencyService.App.Data.Repository.Impl
{
    public class RequestDetailRepository : IRequestDetailsRepository
    {
        private static ILogger _logger;
        private string _conn;
        public RequestDetailRepository(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
            _conn = ConnectionStringInitialiser.InitConnectionString();
        }

        public void AddCasualtyToRequestDetail(int requestNumber, int casualtyId)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertRequestCasualty", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestNumber},
                    new SqlParameter() { ParameterName = "@IdCasualty", Value = casualtyId}
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

        public void AddInventoryToRequestDetail(int requestNumber, int inventoryNumber)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertInventoryRequestDetails", conn) { CommandType = CommandType.StoredProcedure };

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

        public void Create(RequestDetailModel requestDetailModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("InsertRequestDetails", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestDetailModel.RequestNumber},
                    new SqlParameter() { ParameterName = "@IncidentInformation", Value = requestDetailModel.IncidentInformation},
                    new SqlParameter() { ParameterName = "@IncidentReason", Value = requestDetailModel.IncidentReason},
                    new SqlParameter() { ParameterName = "@BrigadeNumber", Value = requestDetailModel.BrigadeNumber},
                    new SqlParameter() { ParameterName = "@BrigadeCallDate", Value = requestDetailModel.BrigadeCallDate},
                    new SqlParameter() { ParameterName = "@BrigadeArrivalDate", Value = requestDetailModel.BrigadeArrivalDate},
                    new SqlParameter() { ParameterName = "@BrigadeEndDate", Value = requestDetailModel.BrigadeEndDate},
                    new SqlParameter() { ParameterName = "@BrigadeReturnDate", Value = requestDetailModel.BrigadeReturnDate}
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

        public RequestDetailModel GetRequestDetailsByRequestNumber(int requestNumber)
        {
            RequestDetailModel requestDetail=null;
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand sqlCommand = new SqlCommand("GetRequestDetails", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@RequestNumber", requestNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    requestDetail = new RequestDetailModel
                    {
                        RequestNumber = reader.GetInt32(0),
                        IncidentInformation = reader.GetString(1),
                        IncidentReason = reader.GetString(2),
                        BrigadeNumber = reader.GetInt32(3),
                        BrigadeCallDate = reader.GetDateTime(4),
                        BrigadeArrivalDate = reader.GetDateTime(5),
                        BrigadeEndDate = reader.GetDateTime(6),
                        BrigadeReturnDate = reader.GetDateTime(7)
                    };
                }
            }
            catch (SqlException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return requestDetail;
        }

        public void Edit(RequestDetailModel requestDetailModel)
        {
            SqlConnection conn = new SqlConnection(_conn);
            SqlCommand command = new SqlCommand("UpdateRequestDetails", conn) { CommandType = CommandType.StoredProcedure };

            try
            {
                conn.Open();
                SqlParameter[] sqlParameters = {
                    new SqlParameter() { ParameterName = "@RequestNumber", Value = requestDetailModel.RequestNumber},
                    new SqlParameter() { ParameterName = "@IncidentInformation", Value = requestDetailModel.IncidentInformation},
                    new SqlParameter() { ParameterName = "@IncidentReason", Value = requestDetailModel.IncidentReason},
                    new SqlParameter() { ParameterName = "@BrigadeNumber", Value = requestDetailModel.BrigadeNumber},
                    new SqlParameter() { ParameterName = "@BrigadeCallDate", Value = requestDetailModel.BrigadeCallDate},
                    new SqlParameter() { ParameterName = "@BrigadeArrivalDate", Value = requestDetailModel.BrigadeArrivalDate},
                    new SqlParameter() { ParameterName = "@BrigadeEndDate", Value = requestDetailModel.BrigadeEndDate},
                    new SqlParameter() { ParameterName = "@BrigadeReturnDate", Value = requestDetailModel.BrigadeReturnDate}
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

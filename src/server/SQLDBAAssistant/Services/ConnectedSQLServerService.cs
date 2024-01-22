using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using server.Services.Interfaces;
using SQLDBAAssistant.Context;
using SQLDBAAssistant.Dto;
using System.Text.Json;

namespace server.Services
{
    public class ConnectedSQLServerService : IConnectedSQLServerService
    {

        private readonly IConfiguration _config;
        private SqlConnection _connection;
        private IStoreRepository _repository;
        private static string _connectionString;

        private JsonSerializerOptions _JsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public ConnectedSQLServerService(IConfiguration config, IStoreRepository repository)
        {
            _config = config;
            _repository = repository;
            _connectionString = _config.GetConnectionString("ConnectionMSSQL");
        }

        public Dictionary<string, string> GetAllMetrics()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                foreach (var query in _repository.GetAllQueryName())
                {
                    SQLResponse? response = ExecuteQueryByTitle(query.Title);
                    if (response != null)
                        result.Add(
                                response?.QueryName,
                                JsonSerializer.Serialize(response?.SelectQuery, _JsonOptions)
                        );
                }
                return result;
            }
        }

        public SQLResponse? ExecuteQueryByTitle(string title)
        {
            var queryFromDb = _repository.GetQueryByTitle(title);
            if (queryFromDb == null)
                return null;

            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(queryFromDb.TextQuery, _connection);

                SQLResponse result = new SQLResponse
                {
                    QueryName = title
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var columnsName = reader.GetColumnSchema().ToList();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
    
                        for (int i = 0; i < columnsName.Count; i++)
                        {
                            row.Add(columnsName[i].ColumnName.ToString(), reader[i].ToString());
                        }
                        result.SelectQuery.Add(row);
                    }
                }
                return result;
            }
        }
    }
}

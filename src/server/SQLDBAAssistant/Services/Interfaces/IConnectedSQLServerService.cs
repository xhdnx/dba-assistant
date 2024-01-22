using SQLDBAAssistant.Dto;

namespace server.Services.Interfaces
{
    public interface IConnectedSQLServerService
    {
        Dictionary<String, String> GetAllMetrics();
        SQLResponse? ExecuteQueryByTitle(String title);
    }
}

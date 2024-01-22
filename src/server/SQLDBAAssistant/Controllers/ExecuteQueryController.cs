using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using SQLDBAAssistant.Dto;

namespace SQLDBAAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExecuteQueryController : ControllerBase
    {
        private readonly ILogger<ExecuteQueryController> _logger;
        private IConnectedSQLServerService _clientSqlServer;

        public ExecuteQueryController(ILogger<ExecuteQueryController> logger, IConnectedSQLServerService clientSqlServer)
        {
            _logger = logger;
            _clientSqlServer = clientSqlServer;
        }

        [HttpGet("api/v1")]
        public ActionResult GetAllMetrics()
        {
            try
            {
                return new JsonResult(_clientSqlServer.GetAllMetrics());
            }
            catch
            {
                _logger.LogError("Ошибка в GetAllMetrics.");
                return BadRequest("Возникла ошибка на стороне сервиса. Текст ошибки можно увидеть в логах");
            }
        }


        [HttpGet("api/v1/{queryName}")]
        public ActionResult GetMetricByQueryName(string queryName)
        {
            if (queryName != null)
            {
                try
                {
                    return new JsonResult(
                        _clientSqlServer.ExecuteQueryByTitle(queryName)
                        ?.SelectQuery
                        );
                }
                catch
                {
                    _logger.LogError("Ошибка в GetMetricByQueryName.");
                    return BadRequest("Возникла ошибка на стороне сервиса. Текст ошибки можно увидеть в логах");
                }
            }
            return BadRequest("QueryName == null. Убедитесь что запрос содержит название необходимого SQL запроса."); //Вернуть код ошибки и текст "Не удалось определить параметр запроса"
        } 
    }
}
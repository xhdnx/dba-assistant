using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using SQLDBAAssistant.Context;

namespace SQLDBAAssistant.Controllers.SQLite
{
    public class QueryController : Controller
    {
        private readonly ILogger<QueryController> _logger;

        public QueryController(ILogger<QueryController> logger)
        {
            _logger = logger;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using SQLDBAAssistant.Context;

namespace SQLDBAAssistant.Controllers.SQLite
{
    public class ConnectionController : Controller
    {
        private readonly ILogger<ConnectionController> _logger;

        public ConnectionController(ILogger<ConnectionController> logger)
        {
            _logger = logger;
        }
    }
}

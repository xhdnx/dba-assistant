using Microsoft.AspNetCore.Mvc;
using SQLDBAAssistant.Context;
using SQLDBAAssistant.Models.SQLiteModels;


namespace SQLDBAAssistant.Controllers.SQLite
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

        }

        //[HttpPost]
        //public HttpResponseMessage CreateUser([FromBody] User user)
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace authf.Controllers
{
    // [ApiController]
    // [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public AuthController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            using (var db = new AuthContext()) 
                return db.Accounts.ToArray();
        }

        [HttpGet]
        public async Task<string> New(string email = "") 
        {
            if(email == "") return "false";

            using (var db = new AuthContext()) {
                db.Accounts.Add(new Account { Email = email });
                await db.SaveChangesAsync();
            }

            return "true";
        }

        // [HttpGet]
        // public async void Clear() 
        // {
        //     using (var db = new AuthContext()) {
        //         db.Accounts.RemoveRange(db.Accounts.ToArray());
        //         await db.SaveChangesAsync();
        //     }
        // }
    }
}

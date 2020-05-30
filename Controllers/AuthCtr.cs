using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authf.Libraries;
using authf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace authf.Controllers
{
    // [ApiController]
    // [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> Gen(string name = "", string pass = "") {

            using (var db = new AuthContext()) {
                db.Accounts.Add(new Account {
                    Email = name,
                    Passhash = new PasswordHash(pass).ToString()
                });
                db.SaveChangesAsync();
                return db.Accounts.ToArray();
            }
        }

        [HttpGet]
        public IEnumerable<Account> Get() {
            using (var db = new AuthContext()) 
                return db.Accounts.ToArray();
        }

        [HttpPost] // New Account
        public async Task<bool> New([FromBody] ApiAuth auth) {
            bool x = false;
            
            // Is Blank Email
            if(auth.Email == "") return x; 
            var passhash = new PasswordHash(auth.Password);

            using (var db = new AuthContext()) {

                // Is Email Taken
                if(db.Accounts.Any(acc => acc.Email == auth.Email)) {}

                else {
                    db.Accounts.Add(new Account { Email = auth.Email, Guard = 0, Passhash = passhash.ToString() });
                    await db.SaveChangesAsync();
                    x = true;
                }
            }

            return x;
        }

        [HttpPost]
        public bool Test([FromBody] ApiAuth auth) {
            bool x = false;

            if(auth.Email == "") return x;
            
            using (var db = new AuthContext()) {
                var account = db.Accounts.First(acc => acc.Email == auth.Email);
                if(account == null || account.Passhash == null) {}
                else {
                    var pass = PasswordHash.FromString(account.Passhash);
                    x = pass.Verify(auth.Password);
                }
            }
            return x;
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

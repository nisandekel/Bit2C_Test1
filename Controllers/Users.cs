using Bit2C_Test1.Classes;
using Bit2C_Test1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit2C_Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpPost]
        [Route("createuser")]
        public void CreateUser([FromBody] UserModel newUser)
        {
            User user = new User();
            user.Init(newUser);
            user.CreateUser();
        }

        [HttpPost]
        [Route("signin")]
        public bool SignIn([FromBody] UserModel newUser)
        {
            User user = new User();
            user.Init(newUser);
            return user.AuthenticateAccount();
        }
    }
}

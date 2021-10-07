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
        public void CreateUser([FromBody] UserModel newAccount)
        {

        }

        [HttpGet]
        public void SignIn()
        {

        }


    }
}

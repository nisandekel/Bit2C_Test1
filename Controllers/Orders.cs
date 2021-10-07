using Bit2C_Test1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit2C_Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {

        [HttpPost]
        public void CreateOrder([FromBody] OrderModel newOrder)
        {

        }

        [HttpGet]
        public Task<List<OrderModel>> GetAllOrders()
        {

        }

    }
}

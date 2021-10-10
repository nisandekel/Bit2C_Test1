using Bit2C_Test1.Classes;
using Bit2C_Test1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Bit2C_Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {

        [HttpPost]
        [Route("createorder")]
        public void CreateOrder([FromBody] OrderModel newOrder)
        {
            Order order = new Order();
            order.Init(newOrder);
            order.CreateOrder();
        }

        [HttpGet("{email}")]
        [Route("getallorders")]
        public string GetAllOrders()
        {
            string email = HttpContext.Request.Query["email"].ToString();
            Order order = new Order();
            order.Init();
            List<OrderModel> orderList = new List<OrderModel>();
            orderList = order.GetOrders(email);
            string orderListJson = JsonSerializer.Serialize(orderList);
            return orderListJson;
        }

    }
}

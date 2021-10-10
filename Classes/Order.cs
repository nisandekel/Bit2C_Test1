using Bit2C_Test1.DataBase;
using Bit2C_Test1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit2C_Test1.Classes
{
    public class Order
    {
        private string _type;
        private string _price;
        private string _amount;
        private string _userName;
        private DBService _dbService;

        public string Type { get { return _type; } }
        public string Price { get { return _price; }  }
        public string Amount { get { return _amount; } }
        public string UserName { get { return _userName; } }

        public void Init(OrderModel orderModel)
        {
            this._type = orderModel.Type;
            this._price = orderModel.Price;
            this._amount = orderModel.Amount;
            this._userName = orderModel.UserName;
            this._dbService = new DBService();
        }

        public void CreateOrder()
        {
            this._dbService.CreateOrder(this);
        }

        public List<OrderModel> GetOrders(string userName)
        {
            return this._dbService.GetOrders(userName);
        }
    }
}

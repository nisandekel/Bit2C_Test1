using Bit2C_Test1.DataBase;
using Bit2C_Test1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit2C_Test1.Classes
{
    public class User
    {
        private string _email;
        private string _password;
        private DBService _dbService;

        public string Email { get { return _email; } }
        public string Password { get { return _password; } }

        public void Init(UserModel userModel)
        {
            this._email = userModel.Email;
            this._password = userModel.Password;
            _dbService = new DBService();
        }

        public void CreateUser()
        {
            this._dbService.CreateUser(this);
        }

        public bool AuthenticateAccount()
        {
            List<UserModel> users = this._dbService.GetAllUsers();
            bool isValid = false;
            foreach(UserModel userModel in users)
            {
                if(userModel.Email == this._email && userModel.Password == this._password)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}

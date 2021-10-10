using Bit2C_Test1.Classes;
using Bit2C_Test1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Bit2C_Test1.DataBase
{
    public class DBService
    {
        private string _connectionString;

        public DBService()
        {
            _connectionString = "Data Source=DESKTOP-CPKF30L;Initial Catalog=Bit2CProject;Integrated Security=True";
        }

        public void CreateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = user.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllUsers", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserModel user = new UserModel();
                        user.UserName = reader["userName"].ToString();
                        user.Password = reader["password"].ToString();
                        users.Add(user);
                    }
                    con.Close();
                }

            }
            return users;
        }

        public void CreateOrder(Order order)
        {

            using (SqlConnection con = new SqlConnection(this._connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Price", SqlDbType.VarChar, 50).Value = order.Price;
                    cmd.Parameters.Add("@Amount", SqlDbType.VarChar, 50).Value = order.Amount;
                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = order.Type;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = order.UserName;
        

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public List<OrderModel> GetOrders(string userName)
        {
            List<OrderModel> orders = new List<OrderModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = userName;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderModel order = new OrderModel();
                        order.Price = reader["price"].ToString();
                        order.Amount = reader["amount"].ToString();
                        order.Type = reader["type"].ToString();
                        order.UserName = reader["userName"].ToString();
                    }
                    con.Close();
                }

            }
            return orders;
        }



    }
}

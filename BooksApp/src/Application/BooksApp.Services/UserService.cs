using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Services
{
    public class UserService : IUserService
    {

        private List<User> users;

        public UserService()
        {
            users = new List<User>()
            {
                new(){ Id=1, Name="Busra", Password="123", Email="abc@xyz.com", Role="Admin"},
                new(){ Id=1, Name="Busra", Password="123", Email="abc@xyz.com", Role="Customer"},
                new(){Id=1, Name="Turkay", Password="123", Email="abc@xyz.com", Role="Customer"}


            };
        }
        public User ValidateUser(string name, string password)
        {
            return users.SingleOrDefault(n => n.Name == name && n.Password == password);
        }
    }
}

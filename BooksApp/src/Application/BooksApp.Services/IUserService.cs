using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Entities;

namespace BooksApp.Services
{
    public interface IUserService
    {

        User ValidateUser(string Name, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;

namespace CityPoi.Services
{
    public interface IUserRepository
    {
       void AddUser(User user );
       bool IsValid(string username, string password);
       string getRole(string username);
    }
}

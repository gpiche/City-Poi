using System;
using System.Linq;
using CityPoi.Entities;
using CityPoi.Services;

namespace CityPoi.DataAccesLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsValid(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user.Password.Equals(password))
            {
                return true;
            }

            return false;
        }

        public string getRole(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user.Role;
        }
    }
}
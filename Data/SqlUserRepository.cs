using System;
using System.Collections.Generic;
using System.Linq;
using UserService.Dtos;
using UserService.Helpers;
using UserService.Models;

namespace UserService.Data
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public SqlUserRepository(UserContext context)
        {
            _context = context;
        }

        // Save data to replicate in data base
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Create new user in DB
        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        // Retrieve user by id from DB
        public User GetUserById(int Id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == Id);
        }

        // Retrieve all users from DB
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public IEnumerable<User> GetUsers(UserParametersDto userParametersDto)
        {
            if(userParametersDto == null)
            {
                throw new ArgumentNullException(nameof(userParametersDto));
            }

            var users = _context.Users as IQueryable<User>;

            if (!string.IsNullOrWhiteSpace(userParametersDto.orderBy))
            {
                users = users.Sort(sortBy: userParametersDto.orderBy, descending: userParametersDto.descending);
            }

            if (string.IsNullOrWhiteSpace(userParametersDto.email)
                 && string.IsNullOrWhiteSpace(userParametersDto.phone))
            {
                return users.ToList();
            }

            if (!string.IsNullOrWhiteSpace(userParametersDto.email))
            {
                var email = userParametersDto.email.Trim();
                users = users.Where(a => a.Email == email);
            }

            if (!string.IsNullOrWhiteSpace(userParametersDto.phone))
            {
                var phone = userParametersDto.phone.Trim();
                users = users.Where(a => a.Phone == phone);
            }

            return users.ToList();
        }

        public void UpdateUser(User user)
        {
            // nothing
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public void OrderUsers(string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
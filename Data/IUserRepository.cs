using System.Collections.Generic;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Data
{
    public interface IUserRepository
    {
        bool SaveChanges();
        IEnumerable<User> GetUsers();        
        IEnumerable<User> GetUsers(UserParametersDto userParametersDto);
        User GetUserById(int Id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void OrderUsers(string orderBy);
    }
}
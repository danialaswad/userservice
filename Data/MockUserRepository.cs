using System.Collections.Generic;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Data
{
    public class MockUserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var Users = new List<User>
            {
                new User{Id=0, FullName="Danial", Email="a@a.com"},
                new User{Id=1, FullName="Aswad", Email="b@b.com"}
            };

            return Users;
        }

        public User GetUserById(int Id)
        {
            return new User{Id=0, FullName="Danial", Email="a@a.com"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void OrderUsers(string orderBy)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers(UserParametersDto userParametersDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
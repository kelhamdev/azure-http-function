using System;
using System.Collections.Generic;
using System.Linq;
using HttpTrigger.Interfaces;
using HttpTrigger.Models;

namespace HttpTrigger.Business
{
    public class UsersBusiness : IUsersBusiness
    {
        private IList<Users> _users = new List<Users>();

        public UsersBusiness()
        {
            SetupUsers();
        }

        public IEnumerable<Users> GetUsers()
        {
            return _users;
        }

        public Users GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        private void SetupUsers()
        {
            _users = new List<Users>
            {
                new Users {DateOfBirth = DateTime.Now, FirstName = "Joe", LastName = "Bloggs", Id = 1},
                new Users {DateOfBirth = DateTime.Now, FirstName = "John", LastName = "Smith", Id = 2},
                new Users {DateOfBirth = DateTime.Now, FirstName = "Fred", LastName = "Jones", Id = 3}
            };
        }
    }
}

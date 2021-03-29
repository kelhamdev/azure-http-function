using System;
using System.Collections.Generic;
using System.Text;
using HttpTrigger.Models;

namespace HttpTrigger.Interfaces
{
    public interface IUsersBusiness
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
    }
}

using ApiService.Core;
using System.Collections.Generic;

namespace ApiService.Manager
{
    public interface IUserManager
    {
        User GetById(string id);
        List<User> GetAll();
        User Insert(User user);
        User Update(User user);
        void Delete(string id);
    }
}

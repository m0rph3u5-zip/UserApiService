using System;
using System.Collections.Generic;
using ApiService.Core;
using ApiService.Request;
using MongoDB.Bson;

namespace ApiService.Manager
{
    public interface IUserManager
    {
        User GetById(string id);
        List<User> GetAll();
        User Insert(User user);
        void Update(User user);
        void Delete(string id);
    }
}

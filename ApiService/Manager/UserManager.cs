using System;
using System.Collections.Generic;
using ApiService.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiService.Manager
{
    public class UserManager : IUserManager
    {

        private readonly IMongoCollection<User> _userCollection;

        public UserManager(IMongoCollection<User> userCollection)
        {
            _userCollection = userCollection;

            var client = new MongoClient(
                "mongodb+srv://admin:VyjVOxXG8zlE3OCT@cluster0-cpssc.mongodb.net/UserDB?retryWrites=true&w=majority"
            );
            var database = client.GetDatabase("UserDB");
            _userCollection = database.GetCollection<User>("UserDB");
        }

        public void Delete(string userId)
        {
            _userCollection.DeleteOne(u => u.Id == userId);
        }

        public List<User> GetAll()
        {
            return _userCollection.Find(u => true).ToList();
        }

        public User GetById(string id)
        {
            return _userCollection.Find(u => u.Id == id).FirstOrDefault();
        }

        public User Insert(User user)
        {
            _userCollection.InsertOne(user);
            return user;
        }

        public void Update(User user)
        {
            _userCollection.ReplaceOne(u => u.Id == user.Id, user);
        }
    }
}

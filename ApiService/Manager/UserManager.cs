using ApiService.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ApiService.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IMongoCollection<User> UserCollection;

        // remote mongodb path [Atlas]
        // mongodb+srv://admin:VyjVOxXG8zlE3OCT@cluster0-cpssc.mongodb.net/UserDB?retryWrites=true&w=majority
        public UserManager()
        {
            var client = new MongoClient(
                "mongodb://127.0.0.1:27017"
            );
            IMongoDatabase database = client.GetDatabase("UserDB");
            UserCollection = database.GetCollection<User>("user");
        }

        public List<User> GetAll()
        {
            return UserCollection.Find(u => true).ToList();
        }

        public User GetById(string id)
        {
            return UserCollection.Find(u => u.Id == id).FirstOrDefault();
        }

        public User Insert(User user)
        {
            
            try
            {
                User userAdded = new User();
                userAdded = user;
                UserCollection.InsertOne(userAdded);
                return user;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public User Update(User user)
        {
            UserCollection.ReplaceOne(u => u.Id == user.Id, user);
            return user;
        }
        public void Delete(string userId)
        {
            UserCollection.DeleteOne(u => u.Id == userId);
        }
    }
}

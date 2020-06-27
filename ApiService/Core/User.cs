using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiService.Core
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address DefaultAddress { get; set; }
        public Addons Information { get; set; }
        public string Fullmane => LastName + " " + FirstName;
        public User()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }
        }
    }
}

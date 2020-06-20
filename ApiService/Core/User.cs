using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiService.Core
{
    public class User
    {
        [BsonId]
        public string Id {
            get => Id;
            set => Id = Id == null ? Guid.NewGuid().ToString() : null;
        }
        public string Surname { get; set; }
        public string Name { get; set; }
        public Address DefaultAddress { get; set; }
        public InfoUser UserInfo { get; set; }
        public string Fullmane
        {
            get => Surname + " " + Name;
        }
    }

    public class InfoUser
    {
        public string Gender { get; set; }
        public string FiscalCode { get; set; }
        public DateTime DateBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
    }

}

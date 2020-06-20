using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ApiService.Core
{
    public class Address
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AddressRow1 { get; set; }
        public string AddressRow2 { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        [BsonId]
        public string UserId { get; set; }
    }
}

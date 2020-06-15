using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiService.Core
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public char Sesso { get; set; }
        public string CodiceFiscale { get; set; }
        public List<Address> Addresses { get; set; }
        public InfoUser InfoUser { get; set; }
        public string Nominativo
        {
            get
            {
                return this.Nome + this.Cognome;
            }
        }
    }

    public class Address
    {
        public string Name { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string Tel { get; set; }
        public string Pv { get; set; }
        public string ZipCode { get; set; }
    }

    public class InfoUser
    {
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Pv { get; set; }
        public string ZipCode { get; set; }
    }
}

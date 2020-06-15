using System;
namespace ApiService.Request
{
    public class UserRequest
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public char Sesso { get; set; }
        public string CodiceFiscale { get; set; }
    }
}

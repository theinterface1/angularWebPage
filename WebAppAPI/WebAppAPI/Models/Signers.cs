using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppAPI.Models
{
    public class Signers
    {
        public int SignerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
   public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}

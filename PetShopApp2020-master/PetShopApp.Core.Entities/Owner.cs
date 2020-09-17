using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
   public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Pet> Pet { get; set; }
    }
}

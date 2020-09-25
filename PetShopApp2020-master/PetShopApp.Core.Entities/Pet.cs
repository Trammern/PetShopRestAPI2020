using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entities
{
   public class Pet
    {
        public int PetId { get; set; }

        public string PetName { get; set; }

        public string PetTypers { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public string PreviousOwner { get; set; }

        public double Price { get; set; }
        public Owner owner { get; set; }
        public List <PetTypes> pettyper { get; set; }
        

     
    }
}

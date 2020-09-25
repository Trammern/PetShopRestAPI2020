using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetShopApp.Core.Entities
{
   public class PetTypes
    {
        [Key]
        public int TypeId { get; set; }
        public string PetType { get; set; }
        public string Race { get; set; }
        public Pet pet { get; set; }
    }
}

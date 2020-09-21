using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace PetShopApp.Infrastructure.Data
{
    /// <summary>
    /// Fake database
    /// </summary>
    public class FakeDB
    {
        public static int PetId = 1;
        public static List<Pet> pets = new List<Pet>();

        public static int OwnerId = 1;
        public static List<Owner> Owners = new List<Owner>();

        public static int TypeId = 1;
        public static List<PetTypes> PetTyper = new List<PetTypes>();


 

    }
}

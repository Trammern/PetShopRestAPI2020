using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

namespace PetShopApp.Infrastructure.Data
{
    public class Datainitializer
    {

        /// <summary>
        /// Mock data of all entyties
        /// </summary>
        public static void InitData()
        {
 
            var p = new Pet()
            {
                PetId = FakeDB.PetId++,
                PetName = "Bob",
                PetType = "Cat",
                BirthDay = DateTime.Now.AddDays(-10),
                Color = "Green",
                PreviousOwner = "",
                Price = 1000,
               
        };
            Owner own = new Owner();
            Pet p1 = new Pet();
            p1.PetId = FakeDB.PetId++;
            p1.PetName = "Dingo";
            p1.PetType = "Dog";
            p1.BirthDay = DateTime.Now.AddDays(-20);
            p1.Color = "Brown";
            p1.PreviousOwner = "Jørgen";
            p1.Price = 2500;
            p1.owner = own;

            Owner own1 = new Owner();
            Pet p2 = new Pet();
            p2.PetId = FakeDB.PetId++;
            p2.PetName = "Raul";
            p2.PetType = "Fish";
            p2.BirthDay = DateTime.Now.AddDays(-15);
            p2.Color = "Dark Pink";
            p2.PreviousOwner = "Ingolf";
            p2.Price = 6700;
            p2.owner = own1;

            Pet p3 = new Pet();
            p3.PetId = FakeDB.PetId++;
            p3.PetName = "Fido";
            p3.PetType = "Dog";
            p3.BirthDay = DateTime.Now.AddDays(-20);
            p3.Color = "Black";
            p3.PreviousOwner = "Hans";
            p3.Price = 1200;

            Pet p4 = new Pet();
            p4.PetId = FakeDB.PetId++;
            p4.PetName = "Laila";
            p4.PetType = "Dog";
            p4.BirthDay = DateTime.Now.AddDays(-20);
            p4.Color = "Blonde";
            p4.PreviousOwner = "HC";
            p4.Price = 25000;
            

            FakeDB.pets.Add(p);
            FakeDB.pets.Add(p1);
            FakeDB.pets.Add(p2);
            FakeDB.pets.Add(p3);
            FakeDB.pets.Add(p4);


            
            own.OwnerId = FakeDB.OwnerId++;
            own.OwnerFirstName = "Lars";
            own.OwnerLastName = "Bilde";
            own.Address = "Ostevej 1";
            own.PhoneNumber = "12345678";
            own.Email = "This@that.dk";
            
           

            
            own1.OwnerId = FakeDB.OwnerId++;
            own1.OwnerFirstName = "Larsi";
            own1.OwnerLastName = "Bildei";
            own1.Address = "Ostevej 12";
            own1.PhoneNumber = "1234567810";
            own1.Email = "This@that.com";
            

            Owner own2 = new Owner();
            own2.OwnerId = FakeDB.OwnerId++;
            own2.OwnerFirstName = "Larso";
            own2.OwnerLastName = "Bildeo";
            own2.Address = "Ostevej 6";
            own2.PhoneNumber = "12341278";
            own2.Email = "This@that.fr";
            

            FakeDB.Owners.Add(own);
            FakeDB.Owners.Add(own1);
            FakeDB.Owners.Add(own2);

            PetTypes pt = new PetTypes();
            pt.TypeId = FakeDB.TypeId++;
            pt.PetType = "Dog";

            FakeDB.PetTyper.Add(pt);
        }

      
    }
}

using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
    public class Datainitializer
    {

        public static void InitData()
        {

            Pet p = new Pet();
            p.PetId = FakeDB.PetId++;
            p.PetName = "Bob";
            p.PetType = "Cat";
            p.BirthDay = DateTime.Now.AddDays(-10);
            p.Color = "Green";
            p.PreviousOwner = "";
            p.Price = 1000;


            Pet p1 = new Pet();
            p1.PetId = FakeDB.PetId++;
            p1.PetName = "Dingo";
            p1.PetType = "Dog";
            p1.BirthDay = DateTime.Now.AddDays(-20);
            p1.Color = "Brown";
            p1.PreviousOwner = "Jørgen";
            p1.Price = 2500;

            Pet p2 = new Pet();
            p2.PetId = FakeDB.PetId++;
            p2.PetName = "Raul";
            p2.PetType = "Fish";
            p2.BirthDay = DateTime.Now.AddDays(-15);
            p2.Color = "Dark Pink";
            p2.PreviousOwner = "Ingolf";
            p2.Price = 6700;

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

        }
    }
}

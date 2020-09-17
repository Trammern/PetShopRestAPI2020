using PetShopApp.Core.Entities;


using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationServices
{
   public interface IPetService
    {
        Pet NewPet(string petName,
           string petType,
           DateTime birthDay,
           string color,
           string previousOwner,
           double price
           );
        Pet CreatePet(Pet pet);

      //  IEnumerable<Pet> GetAllPets(Filter filter);

        List<Pet> Get3CheapestPets();
        public List<Pet> FindPetsByType(string searchString);
        Pet FindPetById(int Petid);
        FilteredList<Pet> GetAllPets(Filter filter);
      //  Pet GetAllPetsWithOwners(int PetId);

        Pet EditPet(Pet petEdit);

        Pet DeletePet(int Petid);
  



    }
}

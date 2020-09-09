using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainServices
{
    public interface IPetRepository
    {
        void InitData();

        //Create Pet
        Pet Create(Pet pet);

        //Read Pet
        IEnumerable<Pet> ReadAll();
        List<Pet> FindPetsByType(string searchString);
        List<Pet> ReadPets();
        Pet FindPetByID(int petid);

        //Update
        Pet Update(Pet petUpdate);

        //Delete
        Pet DeletePet(int PetId);


      
    }
}

using PetShopApp.Core.Entities;
using System.Collections.Generic;

namespace PetShopApp.Core.ApplicationServices
{
    public interface IPetService
    {
        /// <summary>
        /// Create a new Pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        Pet CreatePet(Pet pet);

        List<Pet> Get3CheapestPets();
        public List<Pet> FindPetsByType(string searchString);
        Pet FindPetById(int Petid);
        FilteredList<Pet> GetAllPets(Filter filter);

        Pet EditPet(Pet petEdit);

        Pet DeletePet(int Petid);
        Pet FindPetReadByIdIncludeOwners(int petId);
    }
}

using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationServices.Services
{
    public class PetServices : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;

        public PetServices(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        #region Create

        /// <summary>
        /// Creates a new Pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        #endregion
      
        #region Read
        /// <summary>
        /// Filters the Pets by PetName
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<Pet> GetAllPets(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "PetName";
            }
            return _petRepo.ReadAll(filter);
        }
        /// <summary>
        /// Find Pet by ID
        /// </summary>
        /// <param name="Petid"></param>
        /// <returns></returns>
        public Pet FindPetById(int Petid)
        {
            return _petRepo.FindPetByID(Petid);
        }


         /// <summary>
         /// Get the 3 cheapest pets
         /// </summary>
         /// <returns></returns>
        public List<Pet> Get3CheapestPets()
        {
            return _petRepo.ReadPets()
                .OrderBy(pet => pet.Price).Take(3)
                .ToList();
        }

        /// <summary>
        /// Find pets by type
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public List<Pet> FindPetsByType(string searchString)
        {
            return _petRepo.FindPetsByType(searchString);
        }
        #endregion

        #region Update

        /// <summary>
        /// Edit and updates a Pet
        /// </summary>
        /// <param name="petEdit"></param>
        /// <returns></returns>
        public Pet EditPet(Pet petEdit)
        {
            var pet = FindPetById(petEdit.PetId);
            pet.PetName = petEdit.PetName;
            pet.PetType = petEdit.PetType;
            pet.BirthDay = petEdit.BirthDay;
            pet.owner = petEdit.owner;
            pet.Color = petEdit.Color;
            pet.PreviousOwner = petEdit.PreviousOwner;
            pet.Price = petEdit.Price;

            return pet;

        }
  
        #endregion

        #region Delete

        /// <summary>
        /// Delete a pet
        /// </summary>
        /// <param name="Petid"></param>
        /// <returns></returns>
        public Pet DeletePet(int Petid)
        {
            return _petRepo.DeletePet(Petid);
        }

        #endregion


    }
}

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
        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet NewPet(string petName, string petType, DateTime birthDay,
           string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {

                PetName = petName,
                PetType = petType,
                BirthDay = birthDay,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price

            };

            return pet;
        }
        #endregion
      
        #region Read
        /// <summary>
        /// Get all pets and sort them by ID
        /// </summary>
        /// <returns> </returns>
       /* public IEnumerable<Pet> GetAllPets()
        {
            _petRepo.ReadPets().Sort((x, y) => x.PetId.CompareTo(y.PetId));
            return _petRepo.ReadPets();

        }
       */
        public FilteredList<Pet> GetAllPets(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "PetName";
            }
            return _petRepo.ReadAll(filter);
        }

        public Pet FindPetById(int Petid)
        {
            return _petRepo.FindPetByID(Petid);
        }

        public List<Pet> Get3CheapestPets()
        {
            return _petRepo.ReadPets()
                .OrderBy(pet => pet.Price).Take(3)
                .ToList();
        }

        public List<Pet> FindPetsByType(string searchString)
        {
            return _petRepo.FindPetsByType(searchString);
        }
        #endregion

        #region Update
        public Pet EditPet(Pet petEdit)
        {
            var pet = FindPetById(petEdit.PetId);
            pet.PetName = petEdit.PetName;
            pet.PetType = petEdit.PetType;
            pet.BirthDay = petEdit.BirthDay;
            pet.Color = petEdit.Color;
            pet.PreviousOwner = petEdit.PreviousOwner;
            pet.Price = petEdit.Price;

            return pet;

           

        }
        /*
        public Pet GetAllPetsWithOwners(int PetId)
        {
            var pet = _petRepo.FindPetByID(PetId);

            pet.owner = _ownerRepo.ReadAll()
                  .Where(owner => owner.Pet.PetId == pet.PetId)
                  .ToList();

            return pet;
        }
        */
        #endregion

        #region Delete
        public Pet DeletePet(int Petid)
        {
            return _petRepo.DeletePet(Petid);
        }

      


        #endregion


    }
}

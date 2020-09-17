using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{

    public class PetRepository : IPetRepository
    {
 
    private static List<Pet> _pet = new List<Pet>();

       /// <summary>
       /// Initialize Mock Data
       /// </summary>
        public void InitData()
        {
            Datainitializer.InitData();
        }

        #region Create
        //Create
        public Pet Create(Pet pet)
        {
            pet.PetId = FakeDB.PetId++;
            FakeDB.pets.Add(pet);
            return pet;
        }
        #endregion

        #region Read
        /// <summary>
        /// Filter the list of Pets else return full list
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<Pet> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = FakeDB.pets.Count;
            filteredList.FilterUsed = filter;

            IEnumerable<Pet> filtering = FakeDB.pets;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "PetName":
                        filtering = filtering.Where(c => c.PetName.Contains(filter.SearchText));
                        break;
                    case "PetType":
                        filtering = filtering.Where(c => c.PetType.Contains(filter.SearchText));
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);
                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(c => prop.GetValue(c, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }

            filteredList.List = filtering.ToList();
            return filteredList;
        }
        public List<Pet> FindPetsByType(string searchString)
        {
            List<Pet> SearchedPets = new List<Pet>();
            foreach (var pet in FakeDB.pets)
            {
                if (pet.PetType.ToLower() == searchString)
                {
                    SearchedPets.Add(pet);
                }
            }
            return SearchedPets;
        }
        public List<Pet> ReadPets()
        {
            return FakeDB.pets;
        }
        
        public IEnumerable<Pet> ReadAll()
        {
            return _pet;
        }
        
        public Pet FindPetByID(int PetId)
        {
            foreach (var pet in FakeDB.pets)
            {
                if (pet.PetId == PetId)
                {
                    return pet;
                }
            }
            return null;
        }
        #endregion

        #region Update
        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.FindPetByID(petUpdate.PetId);
            if (petFromDB != null)
            {
                petFromDB.PetName = petUpdate.PetName;
                petFromDB.PetType = petUpdate.PetType;

                petFromDB.Color = petUpdate.Color;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;

            }
            return null;
        }
        #endregion

        #region Delete
        public Pet DeletePet(int PetId)
        {
            var petFound = this.FindPetByID(PetId);

            if (petFound != null)
            {
                FakeDB.pets.Remove(petFound);
                return petFound;
            }
            return null;
        }
        #endregion
    }
}

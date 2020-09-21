using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationServices.Services
{
    public class TypeService : IPetTypes
    {
        readonly IPetTypeRepository _petTypeRepo;

        public TypeService(IPetTypeRepository typeRepository)
        {
            _petTypeRepo = typeRepository;
        }
        /// <summary>
        /// Create a Type
        /// </summary>
        /// <param name="petType"></param>
        /// <returns></returns>
        public PetTypes CreateType(PetTypes petType)
        {
            return _petTypeRepo.Create(petType);
        }

        /// <summary>
        /// Deletes a Type
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public PetTypes DeleteType(int TypeId)
        {
            return _petTypeRepo.DeleteType(TypeId);
        }

        /// <summary>
        /// Finds a Type with a Id
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public PetTypes FindTypeById(int TypeId)
        {
            return _petTypeRepo.ReadById(TypeId);
        }

        /// <summary>
        /// Filters the Type by Type names
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<PetTypes> GetAllPetTypes(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "PetType";
            }
            return _petTypeRepo.ReadAll(filter);
        }

        /// <summary>
        /// Updates a type
        /// </summary>
        /// <param name="PetTypeUpdate"></param>
        /// <returns></returns>
        public PetTypes UpdateType(PetTypes PetTypeUpdate)
        {
            var petTyper = FindTypeById(PetTypeUpdate.TypeId);
            
            petTyper.PetType = PetTypeUpdate.PetType;
            petTyper.Race = PetTypeUpdate.Race;

            return petTyper;
        }
    }
}

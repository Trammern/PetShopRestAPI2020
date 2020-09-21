using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Infrastructure.Data
{
    public class TypeRepository : IPetTypeRepository
    {
        /// <summary>
        /// Initialize the Data
        /// </summary>
        public void InitData()
        {
            if (FakeDB.PetTyper.Count > 0) return;
            {
                Datainitializer.InitData();
            }
        }

        /// <summary>
        /// Creates a Pettype
        /// </summary>
        /// <param name="petTypes"></param>
        /// <returns></returns>
        public PetTypes Create(PetTypes petTypes)
        {
            petTypes.TypeId = FakeDB.TypeId++;
            FakeDB.PetTyper.Add(petTypes);
            return petTypes;
        }

        /// <summary>
        /// Delete a Pettype
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public PetTypes DeleteType(int TypeId)
        {
            var typeFound = this.ReadById(TypeId);

            if (typeFound != null)
            {
                FakeDB.PetTyper.Remove(typeFound);
                return typeFound;
            }
            return null;
        }

        /// <summary>
        /// Filters the list of pettypes
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<PetTypes> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<PetTypes>();

            filteredList.TotalCount = FakeDB.PetTyper.Count;
            filteredList.FilterUsed = filter;

            IEnumerable<PetTypes> filtering = FakeDB.PetTyper;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "PetTypes":
                        filtering = filtering.Where(c => c.PetType.Contains(filter.SearchText));
                        break;
                    case "Race":
                        filtering = filtering.Where(c => c.Race.Contains(filter.SearchText));
                        break;

                }
            }
            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(PetTypes).GetProperty(filter.OrderProperty);
                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(c => prop.GetValue(c, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }
            filteredList.List = filtering.ToList();
            return filteredList;
        }

        /// <summary>
        /// Reads the pettyps by ID
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public PetTypes ReadById(int TypeId)
        {
            foreach (var petType in FakeDB.PetTyper)
            {
                if (petType.TypeId == TypeId)
                {
                    return petType;
                }
            }
            return null;
        }

        /// <summary>
        /// Updates the pettypes
        /// </summary>
        /// <param name="typeUpdate"></param>
        /// <returns></returns>
        public PetTypes UpdateTypes(PetTypes typeUpdate)
        {
            PetTypes typeFromDB = ReadById(typeUpdate.TypeId);
            if (typeFromDB != null)
            {
                typeFromDB.PetType = typeUpdate.PetType;
                typeFromDB.Race = typeUpdate.Race;

              
                return typeFromDB;

            }
            return null;
        }
    }
}

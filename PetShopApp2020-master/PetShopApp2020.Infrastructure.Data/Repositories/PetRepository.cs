using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Pet Create(Pet pet)
        {
            if (pet.owner != null)
            {
                _ctx.Attach(pet.owner).State = EntityState.Unchanged;
            }

            var pets = _ctx.PetTable.Add(pet);
            _ctx.SaveChanges();

                return pets.Entity;
        }

        public Pet DeletePet(int PetId)
        {
            {
                var petFound = this.FindPetByID(PetId);

                if (petFound != null)
                {
                    _ctx.PetTable.Remove(petFound);
                    _ctx.SaveChanges();
                    return petFound;
                }
                return null;
            }
        }

        public Pet FindPetByID(int petid)
        {
            return _ctx.PetTable.FirstOrDefault(p => p.PetId == petid);
        }
        public Pet ReadByIdIncludeOwners(int petId)
        {
            return _ctx.PetTable
               .AsNoTracking()
               .Include(c => c.owner)
               .Include(pt => pt.pettyper)
               .FirstOrDefault(c => c.PetId == petId);
        }

        public List<Pet> FindPetsByType(string searchString)
        {
            throw new NotImplementedException();
        }

        public FilteredList<Pet> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = _ctx.PetTable.Count();
            filteredList.FilterUsed = filter;

            IEnumerable<Pet> filtering = _ctx.PetTable.Include(c => c.owner).Include(pt => pt.pettyper);

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "PetName":
                        filtering = filtering.Where(c => c.PetName.Contains(filter.SearchText));
                        break;
                    case "PetType":
                        filtering = filtering.Where(c => c.PetTypers.Contains(filter.SearchText));
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


        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadPets()
        {
            throw new NotImplementedException();
        }
    }
}

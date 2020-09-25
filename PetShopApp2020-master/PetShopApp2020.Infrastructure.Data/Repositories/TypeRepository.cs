using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data.Repositories
{
    public class TypeRepository : IPetTypeRepository
    {
        readonly PetShopAppContext _ctx;

        public TypeRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public PetTypes Create(PetTypes petTypes)
        {
            {
                var petstypes = _ctx.PetTypeTable.Add(petTypes).Entity;
                _ctx.SaveChanges();

                return petTypes;
            }
        }

        public PetTypes DeleteType(int TypeId)
        {
            var typeFound = this.ReadById(TypeId);

            if (typeFound != null)
            {
                _ctx.PetTypeTable.Remove(typeFound);
                _ctx.SaveChanges();
                return typeFound;
            }
            return null;
        }

        public FilteredList<PetTypes> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<PetTypes>();

            filteredList.TotalCount = _ctx.PetTypeTable.Count();
            filteredList.FilterUsed = filter;

            IEnumerable<PetTypes> filtering = _ctx.PetTypeTable;

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

        public PetTypes ReadById(int TypeId)
        {
            foreach (var petType in _ctx.PetTypeTable)
            {
                if (petType.TypeId == TypeId)
                {
                    return petType;
                }
            }
            return null;
        }

        public PetTypes UpdateTypes(PetTypes typeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

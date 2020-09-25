using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public Owner Create(Owner owner)
        {
            var own = _ctx.OwnerTable.Add(owner).Entity;
            _ctx.SaveChanges();

            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            {
                var ownerFound = this.ReadById(id);

                if (ownerFound != null)
                {
                    _ctx.OwnerTable.Remove(ownerFound);
                    _ctx.SaveChanges();
                    return ownerFound;
                }
                return null;
            }
        }

        public FilteredList<Owner> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Owner>();

            filteredList.TotalCount = _ctx.OwnerTable.Count();
            filteredList.FilterUsed = filter;

            IEnumerable<Owner> filtering = _ctx.OwnerTable;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "OwnerFirstName":
                        filtering = filtering.Where(c => c.OwnerFirstName.Contains(filter.SearchText));
                        break;
                    case "OwnersLastName":
                        filtering = filtering.Where(c => c.OwnerLastName.Contains(filter.SearchText));
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Owner).GetProperty(filter.OrderProperty);
                filtering = "ASC".Equals(filter.OrderDirection) ?
                    filtering.OrderBy(c => prop.GetValue(c, null)) :
                    filtering.OrderByDescending(c => prop.GetValue(c, null));

            }

            filteredList.List = filtering.ToList();
            return filteredList;
        }

        public Owner ReadById(int OwnerId)
        {
            return _ctx.OwnerTable.FirstOrDefault(o => o.OwnerId == OwnerId);
        }

        public Owner Update(Owner OwnerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

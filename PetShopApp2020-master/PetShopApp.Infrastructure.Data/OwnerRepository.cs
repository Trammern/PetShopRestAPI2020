using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PetShopApp.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        /// <summary>
        /// Initializ the data
        /// </summary>
        public void InitData()
        {
            if (FakeDB.Owners.Count > 0) return;
            {
                Datainitializer.InitData();
            }
        }

        /// <summary>
        /// Creates a Owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public Owner Create(Owner owner)
        {
            owner.OwnerId = FakeDB.OwnerId++;
            FakeDB.Owners.Add(owner);
            return owner;
        }

        /// <summary>
        /// Filters the owners
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<Owner> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Owner>();

            filteredList.TotalCount = FakeDB.Owners.Count;
            filteredList.FilterUsed = filter;

            IEnumerable<Owner> filtering = FakeDB.Owners;

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
        public Owner DeleteOwner(int OwnerId)
        {
            var ownerFound = this.FindOwnerByID(OwnerId);

            if (ownerFound != null)
            {
                FakeDB.Owners.Remove(ownerFound);
                return ownerFound;
            }
            return null;
        }

        /// <summary>
        /// Reads the Owner by ID
        /// </summary>
        /// <param name="OwnerId"></param>
        /// <returns></returns>
        public Owner ReadById(int OwnerId)
        {
            return FakeDB.Owners.FirstOrDefault(Owner => Owner.OwnerId == OwnerId);
        }

        /// <summary>
        /// Updates the owner
        /// </summary>
        /// <param name="ownerUpdate"></param>
        /// <returns></returns>
        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = this.FindOwnerByID(ownerUpdate.OwnerId);
            if (ownerFromDB != null)
            {
                ownerFromDB.OwnerFirstName = ownerUpdate.OwnerFirstName;
                ownerFromDB.OwnerLastName = ownerUpdate.OwnerLastName;

                ownerFromDB.Address = ownerUpdate.Address;
                ownerFromDB.PhoneNumber = ownerUpdate.PhoneNumber;
                ownerFromDB.Email = ownerUpdate.Email;
                return ownerFromDB;

            }
            return null;
        }

        /// <summary>
        /// Find a Owner by ID
        /// </summary>
        /// <param name="OwnerId"></param>
        /// <returns></returns>
        public Owner FindOwnerByID(int OwnerId)
        {
            foreach (var owner in FakeDB.Owners)
            {
                if (owner.OwnerId == OwnerId)
                {
                    return owner;
                }
            }
            return null;


        }


    }
}

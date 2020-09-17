using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainServices
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner ReadById(int OwnerId);
        FilteredList<Owner> ReadAll(Filter filter);
        Owner Update(Owner OwnerUpdate);
        Owner DeleteOwner(int id);

    }
}

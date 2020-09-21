using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationServices
{
   public interface IOwnerService
    {
 
        Owner CreateOwner(Owner owner);

        FilteredList<Owner> GetAllOwners(Filter filter);

        Owner FindOwnerById(int OwnerID);
       

        Owner UpdateOwner(Owner ownerUpdate);

        Owner DeleteOwner(int OwnerId);
    }
}

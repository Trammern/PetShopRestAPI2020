using PetShopApp.Core.Entities;

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

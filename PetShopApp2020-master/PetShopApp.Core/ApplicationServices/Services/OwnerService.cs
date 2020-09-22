using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;

namespace PetShopApp.Core.ApplicationServices.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;


        public OwnerService(IOwnerRepository ownerRepository,
            IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;

        }
        /// <summary>
        /// Create a Owner in the database
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }


        /// <summary>
        /// Deletes a Owner in the database
        /// </summary>
        /// <param name="OwnerId"></param>
        /// <returns></returns>
        /// 
        public Owner DeleteOwner(int OwnerId)
        {
            return _ownerRepo.DeleteOwner(OwnerId);
        }


        /// <summary>
        /// Finds a Owner by a OwnerId
        /// </summary>
        /// <param name="Ownerid"></param>
        /// <returns></returns>
        public Owner FindOwnerById(int Ownerid)
        {
            return _ownerRepo.ReadById(Ownerid);
        }


        /// <summary>
        /// Updates a Owner
        /// </summary>
        /// <param name="ownerUpdate"></param>
        /// <returns></returns>
        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.OwnerId);
            owner.OwnerFirstName = ownerUpdate.OwnerFirstName;
            owner.OwnerLastName = ownerUpdate.OwnerLastName;
            owner.Address = ownerUpdate.Address;
            owner.PhoneNumber = ownerUpdate.PhoneNumber;
            owner.Email = ownerUpdate.Email;

            return owner;
        }


        /// <summary>
        /// Filters the Owners name and returns a list 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FilteredList<Owner> GetAllOwners(Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchText) && string.IsNullOrEmpty(filter.SearchField))
            {
                filter.SearchField = "OwnerFirstName";
            }
            return _ownerRepo.ReadAll(filter);
        }
    }

}


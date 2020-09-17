using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PetShopApp.Core.ApplicationServices.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepository,
            IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;
            _petRepo = petRepository;
        }
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner DeleteOwner(int OwnerId)
        {
            return _ownerRepo.DeleteOwner(OwnerId);
        }
/*
        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        */
        public Owner NewOwner(string firstName, string lastName, string address,
            string phoneNumber, string email)
        {
            var owner = new Owner()
            {
               OwnerFirstName = firstName,
               OwnerLastName = lastName,
               Address = address,
               PhoneNumber = phoneNumber,
               Email = email
            };

            return owner;
        }
        public Owner FindOwnerById(int Ownerid)
        {
            return _ownerRepo.ReadById(Ownerid);
        }
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


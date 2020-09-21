using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationServices
{
    public interface IPetTypes
    {
      

        PetTypes CreateType(PetTypes petType);

        FilteredList<PetTypes> GetAllPetTypes(Filter filter);

        PetTypes FindTypeById(int TypeId);


        PetTypes UpdateType(PetTypes PetTypeUpdate);

        PetTypes DeleteType(int TypeId);
    }
}

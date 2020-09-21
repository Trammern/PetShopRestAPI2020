using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainServices
{
   public interface IPetTypeRepository
    {
        PetTypes Create(PetTypes petTypes);
        PetTypes ReadById(int TypeId);
        FilteredList<PetTypes> ReadAll(Filter filter);
        PetTypes UpdateTypes(PetTypes typeUpdate);
        PetTypes DeleteType(int TypeId);

    }
}

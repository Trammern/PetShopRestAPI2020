using PetShopApp.Core.Entities;

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

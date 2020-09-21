using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop2020.RestAPI.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class TypesController : ControllerBase
    { 
        private readonly IPetTypes _petTypeService;

    public TypesController(IPetTypes petTypeService)
    {
        _petTypeService = petTypeService;
    }
    
        // GET: api/<TypesController>
        [HttpGet]
        public ActionResult<FilteredList<PetTypes>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petTypeService.GetAllPetTypes(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<TypesController>/5
        [HttpGet("{TypeId}")]
        public ActionResult<PetTypes> Get(int TypeId)
        {
            if (TypeId < 1) return StatusCode(500, "Type does not excist");
            return _petTypeService.FindTypeById(TypeId);
        }

        // POST api/<TypesController>
        [HttpPost]
        public ActionResult<PetTypes> Post([FromBody] PetTypes petTypes)
        {
            if (string.IsNullOrEmpty(petTypes.PetType))
            { 
                return StatusCode(500, "Can not Create Type, try again");

        }

            return _petTypeService.CreateType(petTypes);
        }


        // PUT api/<TypesController>/5
        [HttpPut("{TypeId}")]
        public ActionResult<PetTypes> Put(int TypeId, [FromBody] PetTypes petTypes)
        {
            if (TypeId < 1 || TypeId != petTypes.TypeId)
            {
                return StatusCode(404, "Can not find Type");
            }
            petTypes.TypeId = TypeId;
            return Ok(_petTypeService.UpdateType(petTypes));
        }

        // DELETE api/<TypesController>/5
        [HttpDelete("{TypeId}")]
        public ActionResult<PetTypes> Delete(int TypeId)
        {

            var petType = _petTypeService.DeleteType(TypeId);
            if (petType == null)
            {
                return StatusCode(404, "Did not find Type with that Id" + TypeId);
            }
            return Ok($"Type with Id: {TypeId} is Deleted");
        }
    }
}

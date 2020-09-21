using System;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.Entities;

using PetShopApp.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop2020.RestAPI.Controllers
{
    [Route("api/Pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
      

        public PetsController(IPetService petService)
        {
            _petService = petService;

            if (FakeDB.Owners.Count > 0) return;
            {
                Datainitializer.InitData();
            }
            
        }
        // GET: api/<Pets>
        [HttpGet]
        public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                
                return Ok(_petService.GetAllPets(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<Pets>/5
        [HttpGet("{Petid}")]
       public ActionResult<Pet> Get(int Petid)
        {
            if (Petid < 1) return StatusCode(500, "Pet does not excist");
            return _petService.FindPetById(Petid);
        }

        // POST api/<Pets>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if(string.IsNullOrEmpty(pet.PetName))
            {
             
                return StatusCode(500, "Can not Create Pet, try again");

            }

           return _petService.CreatePet(pet);
        }

        // PUT api/<Pets>/5
        [HttpPut("{Petid}")]
        public ActionResult Put(int Petid, [FromBody] Pet pet)
        {
            if(Petid < 1 || Petid != pet.PetId)
            {
               return StatusCode(404, "Can not find pet");
            }
           
            return Ok(_petService.EditPet(pet));
        }

        // DELETE api/<Pets>/5
        [HttpDelete("{Petid}")]
        public ActionResult<Pet> Delete(int Petid)
        {

         var pet = _petService.DeletePet(Petid);
            if (pet == null) 
            {
                return StatusCode(404, "Did not find Pet with that Id" + Petid);
            }
            if(Petid < 1)
            {
                return NotFound("Error 404, Owner not found");
            }
            return Ok($"Pet with Id: {Petid} is Deleted");
        }
    }
}

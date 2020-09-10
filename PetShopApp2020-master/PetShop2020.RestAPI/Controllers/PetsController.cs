using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly PetShopApp.Core.DomainServices.IPetRepository _petRepo;

        public PetsController(IPetService petService)
        {
            _petService = petService;
            
            Datainitializer.InitData();
        }
        // GET: api/<Pets>
        [HttpGet]
        public List<Pet> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/<Pets>/5
        [HttpGet("{Petid}")]
       public ActionResult<Pet> Get(int Petid)
        {
            if (Petid < 1) return BadRequest("Id must be greater than 0");
           return _petService.FindPetById(Petid);
        }

        // POST api/<Pets>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if(string.IsNullOrEmpty(pet.PetName))
            {
                return BadRequest("Petname is Required for Creating Pets");
            }

          //  return StatusCode(500, "Oh Shit Error");

           return _petService.CreatePet(pet);
        }

        // PUT api/<Pets>/5
        [HttpPut("{Petid}")]
        public ActionResult Put(int Petid, [FromBody] Pet pet)
        {
            if(Petid < 1 || Petid != pet.PetId)
            {
               return BadRequest("ID must be the same");
            }
           
            return Ok(_petService.EditPet(pet));
        }

        // DELETE api/<Pets>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

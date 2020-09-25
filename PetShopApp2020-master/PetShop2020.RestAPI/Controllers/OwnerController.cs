using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationServices;
using PetShopApp.Core.Entities;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop2020.RestAPI.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<FilteredList<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_ownerService.GetAllOwners(filter));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<owner>/5
        [HttpGet("{OwnerId}")]
        public ActionResult<Owner> Get(int OwnerId)
        {
            if (OwnerId < 1) return StatusCode(500, "Owner does not excist");
            return _ownerService.FindOwnerById(OwnerId);
        }

        // POST api/<owner>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.OwnerFirstName))
            {

                return StatusCode(500, "Can not Create Owner, try again");

            }

            return _ownerService.CreateOwner(owner);

        }

        // PUT api/<owner>/5
        [HttpPut("{OwnerId}")]
        public ActionResult Put(int OwnerId, [FromBody] Owner owner)
        {
            if (OwnerId < 1 || OwnerId != owner.OwnerId)
            {
                return BadRequest("ID must be the same");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{OwnerId}")]
        public ActionResult<Owner> Delete(int OwnerId)
        {

            var owner = _ownerService.DeleteOwner(OwnerId);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Owner with that Id" + OwnerId);
            }
            return Ok($"Owner with Id: {OwnerId} is Deleted");
        }
    }
}

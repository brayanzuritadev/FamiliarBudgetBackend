using Data.DTOs;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/families")]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamilyService familyService;

        public FamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpPost]
        public ActionResult<Family> Post(FamilyCreation familyCreation) 
        {
            var family = familyService.CreateFamily(familyCreation);

            if (family==null)
            {
                return BadRequest();
            }

            return family;
        }

        [HttpGet("familyCode")]
        public ActionResult<Family> Get(string  familyCode) 
        {
            var family = familyService.GetFamily(familyCode);
            
            if (family ==null)
            {
                return BadRequest();
            }
            
            return family;
        }
    }
}

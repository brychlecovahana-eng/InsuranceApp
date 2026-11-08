using InsuranceApp.Services;
using InsuranceApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Web.Controllers
{
    [ApiController]
    [Route("api/InsuredPerson")]
    public class InsuredPersonController : Controller
    {
        private InsuredPersonService InsuredPersonService;
        public InsuredPersonController(InsuredPersonService insuredPersonService)
        {
            InsuredPersonService = insuredPersonService;
        }

        [HttpPost]
        [Route("AddInsuredPerson")]
        public async Task<IActionResult> AddNewInsuredPerson([FromQuery] InsuredPerson toAddInsuredPerson)
        {
            await InsuredPersonService.AddInsuredPerson(toAddInsuredPerson);
            return new OkResult();
        }

        [HttpGet]
        [Route("GetInsuredPeopleAsync")]
        public async Task<List<InsuredPerson>> GetInsuredPeopleAsync()
        {
            List<InsuredPerson> insuredPeople = await InsuredPersonService.GetInsuredPersons();
            return insuredPeople;
        }

        [HttpGet]
        [Route("GetInsuredPersonAsync")]
        public async Task<List<InsuredPerson>> GetInsuredPersonAsync([FromQuery] string firstName, [FromQuery] string lastName)
        {
            var result = await InsuredPersonService.GetInsuredPerson(firstName, lastName);
            return result;
        }

        [HttpGet]
        [Route("GetInsuredPersonIdAsync")]
        public async Task<InsuredPerson?> GetInsuredPersonById([FromQuery] int id)
        {
            return await InsuredPersonService.GetInsuredPersonById(id);
        }

        [HttpDelete]
        [Route("DeleteInsuredPersonById")]
        public async Task<IActionResult> DeleteInsuredPersonById([FromQuery]int id)
        {
            var result = InsuredPersonService.DeleteInsuredPerson(id);
            return new OkResult();
        }
    }
}

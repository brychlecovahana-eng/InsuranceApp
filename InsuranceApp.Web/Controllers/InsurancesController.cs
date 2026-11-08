using InsuranceApp.Services;
using InsuranceApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Web.Controllers
{
    [ApiController]
    [Route("api/Insurance")]
    public class InsurancesController : ControllerBase
    {
        private readonly InsuranceService _insuranceService;

        public InsurancesController(InsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Insurance>>> GetAllInsurancePeopleForInsurance()
        {
            var result = await _insuranceService.GetAllInsurances();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetById(int id)
        {
            var result = await _insuranceService.GetInsuranceById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddInsurance([FromQuery] Insurance insurance)
        {
            await _insuranceService.AddInsurance(insurance);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, [FromBody] Insurance insurance)
        {
            bool updated = await _insuranceService.UpdateInsurance(id, insurance);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            bool deleted = await _insuranceService.DeleteInsurance(id);

            if (!deleted)
                return Conflict(
                    "Insurance does not exist or is assigned to an insured person.");

            return NoContent();
        }

    }
}
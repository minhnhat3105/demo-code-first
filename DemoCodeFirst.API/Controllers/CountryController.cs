using DemoCodeFirst.Business.Services.CountrySvc;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Country;
using DemoCodeFirst.Data.ViewModels.Entities.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoCodeFirst.API.Controllers
{
    [Route("api/v1/country")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("search")]
        [SwaggerOperation(Summary = "Get countries by conditions")]
        public async Task<IActionResult> GetCountriesByConditions([FromQuery] CountryRequestModel conditions)
        {
            try
            {
                PagingResult<ViewCountry> countries = await _countryService.GetCountriesByConditions(conditions);
                return Ok(countries);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert a country")]
        public async Task<IActionResult> InsertCountry([FromBody] string name)
        {
            try
            {
                ViewCountry country = await _countryService.Insert(name);
                return Ok(country);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a country")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryUpdateModel model)
        {
            try
            {
                await _countryService.Update(model);
                return Ok();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a country")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                await _countryService.Delete(id);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

using DemoCodeFirst.Business.Services.CitySvc;
using DemoCodeFirst.Data.ViewModels.City;
using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoCodeFirst.API.Controllers
{
    [Route("api/v1/city")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get all city", Description = "abc")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingRequest request)
        {
            try
            {
                PagingResult<ViewCity> cities = await _cityService.GetAllCities(request);
                return Ok(cities);
            }
            catch(NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch(SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get city by id", Description = "abc")]
        public Task<IActionResult> GetCityById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert a city", Description = "abc")]
        public Task<IActionResult> InsertCity(CityInsertModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a city", Description = "abc")]
        public Task<IActionResult> UpdateCity([FromBody] string name)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a city", Description = "abc")]
        public Task<IActionResult> DeleteCity(int id)
        {
            throw new NotImplementedException();
        }
    }
}

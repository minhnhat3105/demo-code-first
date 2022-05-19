using DemoCodeFirst.Business.Services.CitySvc;
using DemoCodeFirst.Data.ViewModels.Entities.City;
using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;
using DemoCodeFirst.Data.RequestModel;

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

        [HttpGet("search")]
        [SwaggerOperation(Summary = "search city by conditions")]
        public async Task<IActionResult> GetCityById([FromQuery] CityRequestModel conditions)
        {
            try
            {
                PagingResult<ViewCity> cities = await _cityService.GetByConditions(conditions);
                return Ok(cities);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insert a city")]
        public async Task<IActionResult> InsertCity(CityInsertModel model)
        {
            try
            {
                ViewCity city = await _cityService.Insert(model);
                return Ok(city);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a city")]
        public async Task<IActionResult> UpdateCity([FromBody] CityUpdateModel model)
        {
            try
            {
                await _cityService.Update(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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
        [SwaggerOperation(Summary = "Delete a city")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityService.Delete(id);
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

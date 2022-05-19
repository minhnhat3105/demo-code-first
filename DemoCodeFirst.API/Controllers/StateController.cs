using DemoCodeFirst.Business.Services.StateSvc;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoCodeFirst.API.Controllers
{
    [Route("api/v1/state")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("search")]
        [SwaggerOperation(Summary = "Get states by conditions")]
        public async Task<IActionResult> GetStatesByConditions([FromQuery] StateRequestModel conditions)
        {
            try
            {
                PagingResult<ViewState> states = await _stateService.GetStatesByConditions(conditions);
                return Ok(states);
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
        [SwaggerOperation(Summary = "Insert a state")]
        public async Task<IActionResult> InsertState(StateInsertModel model)
        {
            try
            {
                ViewState city = await _stateService.Insert(model);
                return Ok(city);
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
        [SwaggerOperation(Summary = "Update a state")]
        public async Task<IActionResult> UpdateState([FromBody] StateUpdateModel model)
        {
            try
            {
                await _stateService.Update(model);
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
        [SwaggerOperation(Summary = "Delete a state")]
        public async Task<IActionResult> DeleteState(int id)
        {
            try
            {
                await _stateService.Delete(id);
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

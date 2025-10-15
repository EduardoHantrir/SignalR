using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalR_Domains.Result;
using SignalR_Errors;

namespace SignalR_API.Controllers
{
    [ApiController]
    [Route("api/v0/group")]
    public class GroupController : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGroupById()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("this")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpGet("search/{query}")]
        [Authorize]
        public async Task<IActionResult> SearchGroups(string query)
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateGroup()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGroup()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGroup()
        {
            try
            {

                return Ok();
            }
            catch (ErrorLists ex)
            {
                return BadRequest(Results<string>.FailureResult(ex.Errors.ToList()));
            }
        }
    }
}

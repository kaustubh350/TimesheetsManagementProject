using MediatR;
using Microsoft.AspNetCore.Mvc;
using TimesheetsManagementProject.Data.Query;
using TimesheetsManagementProject.Models.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimesheetsManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {  
        private IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/project/user/list")]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            var userLists = await _mediator.Send(new GetUserListQuery());
            return Ok(userLists);
        }
    }
}

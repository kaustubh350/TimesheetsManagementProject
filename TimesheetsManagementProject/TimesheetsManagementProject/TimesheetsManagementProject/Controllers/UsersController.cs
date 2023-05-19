using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetsManagementProject.Data.Command;
using TimesheetsManagementProject.Data.Command.ProjectsCommand;
using TimesheetsManagementProject.Data.Command.UsersCommand;
using TimesheetsManagementProject.Data.Query;
using TimesheetsManagementProject.Data.Query.ProjectsQuery;
using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/api/users/save")]
        public async Task<Users> SaveUsers(Users users)
        {
            var response = await _mediator.Send(new SaveUsersCommand
            {
                users = users
            });

            if (response.IsSuccessful == false)
            {
                return null;
            }
            return users;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/api/user/role/save")]
        public async Task<UserRoles> SaveUsersRoles(UserRoles userRoles)
        {
            var response = await _mediator.Send(new SaveUsersRolesCommand
            {
                userRoles = userRoles
            });

            if (response.IsSuccessful == false)
            {
                return null;
            }
            return userRoles;
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

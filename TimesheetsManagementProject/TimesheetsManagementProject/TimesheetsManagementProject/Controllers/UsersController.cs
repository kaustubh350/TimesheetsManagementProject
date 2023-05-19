using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetsManagementProject.Data.Command;
using TimesheetsManagementProject.Data.Command.ProjectsCommand;
using TimesheetsManagementProject.Data.Command.UsersCommand;
using TimesheetsManagementProject.Data.Query.ProjectsQuery;
using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet("/api/users/role/list")]
        //public async Task<ActionResult<List<UserRoles>>> GetAllUserRoles()
        //{
        //    var userRolesLists = await _mediator.Send(new GetAllUserRolesQuery());
        //    return Ok(userRolesLists);
        //}

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
    }
}

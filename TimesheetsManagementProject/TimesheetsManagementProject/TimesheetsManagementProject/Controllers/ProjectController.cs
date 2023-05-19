using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Data.Command.ProjectsCommand;
using TimesheetsManagementProject.Data.Query;
using TimesheetsManagementProject.Data.Query.Client;
using TimesheetsManagementProject.Data.Query.ProjectsQuery;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimesheetsManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : ControllerBase
    {
        private IMediator _mediator;
 
        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/api/projects/save")]
        public async Task<Projects> SaveProjects(Projects projects)
        {
            var response = await _mediator.Send(new SaveProjectsCommand
            {
                projects = projects
            });

            if (response.IsSuccessful == false)
            {
                return null;
            }
            return projects;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/projects/list")]
        public async Task<ActionResult<List<Projects>>> GetAllProjects()
        {
            var projectsLists = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(projectsLists);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("/api/projects/delete")]
        public async Task<IActionResult> DeleteProjects(int ProjectId)
        {
            var response = await _mediator.Send(new DeleteProjectsCommand()
            {
                ProjectId = ProjectId
            });
            if (response == null)
            {
                return null;
            }
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("/api/projects/update")]
        public async Task<Projects> UpdateProjects(int id, Projects projects)
        {
            var response = await _mediator.Send(new UpdateProjectsCommand
            {
                ProjectId = id,
                Projects = projects
            });

            if (response == null)
            {
                return null;
            }

            return projects;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Data.Query;
using TimesheetsManagementProject.Data.Query.Client;
using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientController : ControllerBase
    {
        private IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("/api/client/save")]
        public async Task<Clients> SaveClient(Clients clients)
        {
            var response = await _mediator.Send(new SaveClientCommand
            {
                clients = clients
            });

            if (response.IsSuccessful == false)
            {
                return null;
            }
            return clients;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/api/client/list")]
        //public async Task<ActionResult<List<Clients>>> GetAll()
        //{
        //    var ClientLists = await _mediator.Send(new GetClientQuery());
        //    return Ok(ClientLists);
        //}
        //pooja
        //public ActionResult Get()
        //{
        //    var clientsFromRepo = _unitOfWork.Clients.GetAll().Where(x => x.isDeleted == false);

        //    return Ok(clientsFromRepo);
        //}
        public virtual async Task<IActionResult> GetClients()
        {
            var response = await _mediator.Send(new GetClientQuery());
            return Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("/api/client/delete")]
        public async Task<IActionResult> DeleteClient(int ClientId)
        {
            var response = await _mediator.Send(new DeleteClientCommand()
            {
                ClientId = ClientId
            });
             if (response == null)
            {
                return null;
            }
            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("/api/client/update")]
        public async Task<Clients> UpdateClient(int id, Clients clients)
        {
            var response = await _mediator.Send(new UpdateClientsCommand
            {
                ClientId = id,
                Client = clients
            });

            if (response == null)
            {
                return null;
            }

            return clients;
        }
    }
}

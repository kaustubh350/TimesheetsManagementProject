using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.Client
{
    public class UpdateClientsCommand : IRequest<QueryResponse>
    {
        public Clients Client { get; set; }
        public int ClientId { get; set; }
    }

    public class UpdateClientsCommandHandlers : IRequestHandler<UpdateClientsCommand, QueryResponse>
    {
        private readonly IClientsRepository _clientsRepository;

        public UpdateClientsCommandHandlers(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<QueryResponse> Handle(UpdateClientsCommand request, CancellationToken cancellationToken)
        {
            var saveclient = await _clientsRepository.UpdateClient(request.ClientId,request.Client);

            return new QueryResponse()
            {
                Data = saveclient ?? default,
                IsSuccessful = saveclient != null,
                Errors = saveclient != null ? default : new() { $"You Can not insert new Clients!!!" }
            };

        }
    }
}

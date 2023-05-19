using MediatR;
using System.Runtime.Serialization;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Query.Client;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.Client
{
    public class SaveClientCommand : IRequest<QueryResponse>
    {
        public Clients clients { get; set; }

    }
    public class SaveClientCommandHandlers : IRequestHandler<SaveClientCommand, QueryResponse>
    {
        private readonly IClientsRepository _clientsRepository;

        public SaveClientCommandHandlers(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<QueryResponse> Handle(SaveClientCommand request, CancellationToken cancellationToken)
        {
            var saveclient = await _clientsRepository.SaveClient(request.clients);

            return new QueryResponse()
            {
                Data = saveclient ?? default,
                IsSuccessful = saveclient != null,
                Errors = saveclient != null ? default : new() { $"You Can not insert new Clients!!!" }
            };

        }
    }
}

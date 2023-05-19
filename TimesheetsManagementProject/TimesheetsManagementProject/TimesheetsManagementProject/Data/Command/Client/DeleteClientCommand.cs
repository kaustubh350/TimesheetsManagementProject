using MediatR;
using System.Runtime.Serialization;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.Client
{
    public class DeleteClientCommand : IRequest<QueryResponse>
    {
        [DataMember]
        public int ClientId { get; set; }
    }

    public class DeleteClientCommandHandlers : IRequestHandler<DeleteClientCommand, QueryResponse>
    {
        private readonly IClientsRepository _clientsRepository;

        public DeleteClientCommandHandlers(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<QueryResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var saveclient = await _clientsRepository.DeleteClient(request.ClientId);

            return new QueryResponse()
            {
                Data = saveclient ?? default,
                IsSuccessful = saveclient != null,
                Errors = saveclient != null ? default : new() { $"You Can not insert new Clients!!!" }
            };

        }
    }
}

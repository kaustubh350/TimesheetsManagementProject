using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Query.Client
{
    public class GetClientQuery : IRequest<QueryResponse>
    {
    }

    public class GetClientQueryHandlers : IRequestHandler<GetClientQuery, QueryResponse>
    {
        private readonly IClientsRepository _clientsRepository;

        public GetClientQueryHandlers(IClientsRepository clientsRepository)
        {
            _clientsRepository= clientsRepository;
        }

        public async Task<QueryResponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var clientLists = await _clientsRepository.GetClients();

            return new QueryResponse()
            {
                Data = clientLists.Any() ? clientLists : default,
                IsSuccessful = clientLists.Any(),
                Errors = clientLists.Any() ? default : new() { $"No Matching Records Found !!!" }
            };

        }
    }
}

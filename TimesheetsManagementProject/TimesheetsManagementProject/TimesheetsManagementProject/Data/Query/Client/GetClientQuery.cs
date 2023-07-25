using MediatR;
using NPOI.SS.Formula.Functions;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.GenericRepository;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Query.Client
{
    public class GetClientQuery : IRequest<QueryResponse>
    {
    }

    public class GetClientQueryHandlers : IRequestHandler<GetClientQuery, QueryResponse>
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GetClientQueryHandlers(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async  Task<QueryResponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var clientLists = _genericRepository.GetAll();

            return new QueryResponse()
            {
                Data = clientLists.Any() ? clientLists : default,
                IsSuccessful = clientLists.Any(),
                Errors = clientLists.Any() ? default : new() { $"No Matching Records Found !!!" }
            };

        }
    }
}

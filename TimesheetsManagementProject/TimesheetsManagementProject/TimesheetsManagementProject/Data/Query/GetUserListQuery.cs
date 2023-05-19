using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;
using TimesheetsManagementProject.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimesheetsManagementProject.Data.Query
{
    public class GetUserListQuery : IRequest<QueryResponse>
    {
        [DataMember]
        public int Id { get; set; }
    }
   
    public class GetUserListQueryHandlers : IRequestHandler<GetUserListQuery, QueryResponse>
    {
        private readonly IClientsRepository _clientsRepository;

        public GetUserListQueryHandlers(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<QueryResponse> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userLists = await _clientsRepository.GetClientById(request.Id);

            return new QueryResponse()
            {
                Data = userLists ?? default,
                IsSuccessful = userLists != null,
                Errors = userLists !=null ? default : new() { $"No Matching Records Found !!!" }
            };

        }
    }
}

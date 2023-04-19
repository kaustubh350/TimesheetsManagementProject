using MediatR;
using Microsoft.EntityFrameworkCore;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;
using TimesheetsManagementProject.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimesheetsManagementProject.Data.Query
{
    public class GetUserListQuery : IRequest<QueryResponse>
    {
    }

    public class GetUserListQueryHandlers : IRequestHandler<GetUserListQuery, QueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<QueryResponse> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userLists = await _userRepository.GetUsers();

            return new QueryResponse()
            {
                Data = userLists.Any() ? userLists : default,
                IsSuccessful = userLists.Any(),
                Errors = userLists.Any() ? default : new() { $"No Matching Records Found !!!" }
            };

        }
    }
}

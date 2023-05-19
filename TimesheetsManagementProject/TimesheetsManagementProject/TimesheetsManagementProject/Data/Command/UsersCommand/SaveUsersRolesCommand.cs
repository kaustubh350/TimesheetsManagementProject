using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.UsersCommand
{
    public class SaveUsersRolesCommand : IRequest<QueryResponse>
    {
        public UserRoles userRoles { get; set; }
    }
    public class SaveUsersRolesCommandHandlers : IRequestHandler<SaveUsersRolesCommand, QueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public SaveUsersRolesCommandHandlers(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<QueryResponse> Handle(SaveUsersRolesCommand request, CancellationToken cancellationToken)
        {
            var saveUserRoles = await _userRepository.SaveUserRoles(request.userRoles);

            return new QueryResponse()
            {
                Data = saveUserRoles ?? default,
                IsSuccessful = saveUserRoles != null,
                Errors = saveUserRoles != null ? default : new() { $"You Can not insert new Clients!!!" }
            };

        }
    }
}

using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Command.UsersCommand;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.UsersCommand
{
    public class SaveUsersCommand : IRequest<QueryResponse>
    {
        public Users users { get; set; }
    }

    public class SaveUsersCommandHandlers : IRequestHandler<SaveUsersCommand, QueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public SaveUsersCommandHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<QueryResponse> Handle(SaveUsersCommand request, CancellationToken cancellationToken)
        {
            var saveUsers = await _userRepository.SaveUsers(request.users);

            return new QueryResponse()
            {
                Data = saveUsers ?? default,
                IsSuccessful = saveUsers != null,
                Errors = saveUsers != null ? default : new() { $"You Can not insert new Clients!!!" }
            };
        }
    }
}

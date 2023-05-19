using MediatR;
using System.Runtime.Serialization;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.ProjectsCommand
{
    public class DeleteProjectsCommand : IRequest<QueryResponse>
    {
        [DataMember]
        public int ProjectId { get; set; }
    }
    public class DeleteProjectsCommandHandlers : IRequestHandler<DeleteProjectsCommand, QueryResponse>
    {
        private readonly IProjectsRepository _projectsRepository;

        public DeleteProjectsCommandHandlers(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<QueryResponse> Handle(DeleteProjectsCommand request, CancellationToken cancellationToken)
        {
            var deleteProjects = await _projectsRepository.DeleteProjects(request.ProjectId);

            return new QueryResponse()
            {
                Data = deleteProjects ?? default,
                IsSuccessful = deleteProjects != null,
                Errors = deleteProjects != null ? default : new() { $"You Can not insert new Projects!!!" }
            };

        }
    }
}

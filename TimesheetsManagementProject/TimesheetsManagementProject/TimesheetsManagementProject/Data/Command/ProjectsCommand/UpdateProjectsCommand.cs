using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.ProjectsCommand
{
    public class UpdateProjectsCommand : IRequest<QueryResponse>
    {
        public Projects Projects { get; set; }
        public int ProjectId { get; set; }
    }

    public class UpdateProjectsCommandHandlers : IRequestHandler<UpdateProjectsCommand, QueryResponse>
    {
        private readonly IProjectsRepository _projectsRepository;

        public UpdateProjectsCommandHandlers(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<QueryResponse> Handle(UpdateProjectsCommand request, CancellationToken cancellationToken)
        {
            var updateProject = await _projectsRepository.UpdateProjects(request.ProjectId, request.Projects);

            return new QueryResponse()
            {
                Data = updateProject ?? default,
                IsSuccessful = updateProject != null,
                Errors = updateProject != null ? default : new() { $"You Can not update Project!!!" }
            };

        }
    }
}

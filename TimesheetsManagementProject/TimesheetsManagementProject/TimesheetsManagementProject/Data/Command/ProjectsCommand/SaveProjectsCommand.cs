using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Command.Client;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Repositories;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Command.ProjectsCommand
{
    public class SaveProjectsCommand : IRequest<QueryResponse>
    {
        public Projects projects { get; set; }
    }

    public class SaveProjectsCommandHandlers : IRequestHandler<SaveProjectsCommand, QueryResponse>
    {
        private readonly IProjectsRepository _projectsRepository;

        public SaveProjectsCommandHandlers(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<QueryResponse> Handle(SaveProjectsCommand request, CancellationToken cancellationToken)
        {   
                var saveProjects = await _projectsRepository.SaveProjects(request.projects);

                return new QueryResponse()
                {
                    Data = saveProjects,
                    IsSuccessful = true,
                    Errors = saveProjects != null ? default : new() { $"You Can not insert new Project!!!" }
                };
        }
    }
}

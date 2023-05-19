using MediatR;
using TimesheetsManagementProject.CommonData;
using TimesheetsManagementProject.Data.Query.Client;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Data.Query.ProjectsQuery
{
    public class GetAllProjectsQuery : IRequest<QueryResponse>
    {
    }
    public class GetAllProjectsQueryHandlers : IRequestHandler<GetAllProjectsQuery, QueryResponse>
    {
        private readonly IProjectsRepository _projectsRepository;

        public GetAllProjectsQueryHandlers(IProjectsRepository projectsRepository)
        {
           _projectsRepository= projectsRepository;
        }

        public async Task<QueryResponse> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var clientLists = await _projectsRepository.GetAllProjects();

            return new QueryResponse()
            {
                Data = clientLists.Any() ? clientLists : default,
                IsSuccessful = clientLists.Any(),
                Errors = clientLists.Any() ? default : new() { $"No Matching Records Found !!!" }
            };

        }
    }
}

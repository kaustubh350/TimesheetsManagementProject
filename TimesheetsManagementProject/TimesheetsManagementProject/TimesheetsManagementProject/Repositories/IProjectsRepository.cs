using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Services
{
    public interface IProjectsRepository
    {
        Task<Projects> SaveProjects(Projects projects);
        Task<List<ProjectsResponse>> GetAllProjects();
        Task<Projects> DeleteProjects(int projectId);
        Task<Projects> UpdateProjects(int Id, Projects projects);
    }

    public class ProjectsResponse
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ClientId { get; set; }
        public int ProjectCost { get; set; }
        public int ProjectHeadId { get; set; }
        public int ProjectManagerId { get; set; }
        public int ProjectUserId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
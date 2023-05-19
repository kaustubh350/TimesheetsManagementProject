using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System.Configuration;
using System.Linq.Expressions;
using TimesheetsManagementProject.Data;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;
using TimesheetsManagementProject.Repositories;

namespace TimesheetsManagementProject.Services
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public ProjectsRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        public async Task<Projects> SaveProjects(Projects projects)
        {
            await _dataContext.Projects.AddAsync(projects);
            await _dataContext.SaveChangesAsync();
            return projects;
        }
        public async Task<List<ProjectsResponse>> GetAllProjects()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DataConnectionStrings")))
            {
                var query = $@"
                          SELECT                    
                            p.ProjectId
                            ,p.ProjectName
                            ,p.ProjectCost
                            ,p.ProjectHeadId
                            ,p.ProjectManagerId
                            
                            ,p.Rate
                            ,p.Description
                            ,p.IsActive
                            ,p.IsDeleted
                            ,p.ClientId
     

                        FROM Projects  p
                        WHERE p.IsDeleted = 0
                        ORDER BY p.ProjectId
                            
                    ";

                return (await connection.QueryAsync<ProjectsResponse>(query).ConfigureAwait(false)).ToList();
            }

        }

        public async Task<Projects> DeleteProjects(int projectId)
        {
            var existingProjects = await _dataContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (existingProjects == null)
            {
                return null;
            }

            existingProjects.IsDeleted = true;

            await _dataContext.SaveChangesAsync();

            return existingProjects;
        }

        public async Task<Projects> UpdateProjects(int projectId, Projects projects)
        {
            var existingProject = await _dataContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);

            if (existingProject == null)
            {
                return null;
            }
            existingProject.ProjectName = projects.ProjectName;
            existingProject.ClientId = projects.ClientId;
            existingProject.ProjectCost = projects.ProjectCost;
            existingProject.ProjectHeadId = projects.ProjectHeadId;
            existingProject.ProjectManagerId = projects.ProjectManagerId;
            //existingProject.ProjectUsersId = projects.ProjectUsersId;
            existingProject.Rate = projects.Rate;
            existingProject.Description = projects.Description;
            existingProject.IsDeleted = projects.IsDeleted;
            existingProject.IsActive = projects.IsActive;

            await _dataContext.SaveChangesAsync();

            return existingProject;
        }
    }
}
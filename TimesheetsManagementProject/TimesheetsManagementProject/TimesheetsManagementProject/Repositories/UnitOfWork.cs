using TimesheetsManagementProject.Data;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbcontext;
        public UnitOfWork(DataContext context)
        {
            _dbcontext = context;
            //Clients = new ClientsRepository(_dbcontext);
           // Users = new UserRepository(_dbcontext);
            //Projects = new ProjectsRepository(_dbcontext);
            //Roles = new RoleRepository(_dbcontext);
        }

      

        public IClientsRepository Clients { get; private set; }
        public IProjectsRepository Projects { get; private set; }
        //public IUserRepository Users { get; private set; }
        //public IProjectsRepository Projects { get; private set; }
        //public IRoleRepository Roles { get; private set; }

        public int Save()
        {
            return _dbcontext.SaveChanges();
        }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

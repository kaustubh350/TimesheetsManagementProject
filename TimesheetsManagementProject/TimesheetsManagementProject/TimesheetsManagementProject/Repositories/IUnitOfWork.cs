using TimesheetsManagementProject.Services;

namespace TimesheetsManagementProject.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //IUserRepository Users { get; }
        IClientsRepository Clients { get;}
        IProjectsRepository Projects { get;}
        int Save();
    }
}

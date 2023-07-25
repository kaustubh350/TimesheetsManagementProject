using Microsoft.EntityFrameworkCore;
using TimesheetsManagementProject.Data;

namespace TimesheetsManagementProject.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DataContext _dataContext;
        public DbSet<T> entities;   //for adding

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public  IEnumerable<T> GetAll()
        {
            return  _dataContext.Set<T>().ToList();
        }
    }
}

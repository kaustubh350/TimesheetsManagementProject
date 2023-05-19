using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using TimesheetsManagementProject.Data;
using static Dapper.SqlMapper;

namespace TimesheetsManagementProject.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DataContext _dbContext;
        public DbSet<T> entities;   //for adding
        public GenericRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
      
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entities");
            }
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void SoftDelete(T Entity)
        {
            PropertyInfo isDeletedProp = Entity.GetType().GetProperty("isDeleted");
            if (isDeletedProp != null)
            {
                isDeletedProp.SetValue(Entity, true);
                _dbContext.Set<T>().Update(Entity);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This Entity does not have property named isDeleted");
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Update(T Entity)
        {
            _dbContext.Set<T>().Update(Entity);
            _dbContext.SaveChanges();
        }
    }
}

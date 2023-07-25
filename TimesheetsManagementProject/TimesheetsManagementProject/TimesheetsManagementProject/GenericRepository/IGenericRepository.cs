namespace TimesheetsManagementProject.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {   
        IEnumerable<T> GetAll();
    }
}

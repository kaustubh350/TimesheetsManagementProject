using Microsoft.EntityFrameworkCore;
using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Data
{
    public class DataContext : DbContext
    {   
        //public DataContext()
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if(options.IsConfigured)
        //    {
        //        options.UseSqlServer("Error is coming");
        //    }
        //}
        public DataContext(DbContextOptions<DataContext> options):
            base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
    }
}

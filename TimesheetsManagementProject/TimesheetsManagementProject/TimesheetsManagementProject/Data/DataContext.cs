using Microsoft.EntityFrameworkCore;
using TimesheetsManagementProject.GenericRepository;
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
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Designations> Designations { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectUsers> ProjectUsers { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}

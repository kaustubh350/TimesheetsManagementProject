using TimesheetsManagementProject.Models.Domain;

namespace TimesheetsManagementProject.Services
{
    public interface IUserRepository
    {
      Task<List<UsersResponse>> GetUsers(); 
    }

    public class UsersResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

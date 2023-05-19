using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Dto
{
    public class UsersDto
    {
        [Key]
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public int DesignationId { get; set; }
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public int PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}

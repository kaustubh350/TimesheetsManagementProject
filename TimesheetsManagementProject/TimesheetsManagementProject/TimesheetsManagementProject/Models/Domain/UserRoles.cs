using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Domain
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

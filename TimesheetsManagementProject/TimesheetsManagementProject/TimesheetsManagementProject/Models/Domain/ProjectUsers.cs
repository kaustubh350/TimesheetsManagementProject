using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Domain
{
    public class ProjectUsers
    {
        [Key]
        public int ProjectUserId { get; set; }
        public int ProjectId { get; set; }
       // public List<Projects> Projects { get; set; }
        public int UserId { get; set; }
        //public List<Users> Users { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

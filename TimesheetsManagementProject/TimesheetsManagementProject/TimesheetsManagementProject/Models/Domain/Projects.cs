using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Domain
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ClientId { get; set; }
        public int ProjectHeadId { get; set; }
        public int ProjectManagerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

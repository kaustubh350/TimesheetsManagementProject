using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Dto
{
    public class DesignationsDto
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

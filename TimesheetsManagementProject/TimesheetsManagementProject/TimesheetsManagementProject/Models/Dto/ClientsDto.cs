using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Dto
{
    public class ClientsDto
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int CurrencyId { get; set; }
        public int BillingMethodId { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public int Mobile { get; set; }
        public string Fax { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

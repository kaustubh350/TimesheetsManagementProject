using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using TimesheetsManagementProject.Repositories;

namespace TimesheetsManagementProject.Models.Domain
{
    public class Users 
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

        public List<ProjectUsers> ProjectUsers { get; set; }

        //public UserRoles UserRolesRoles { get; set; }
        //public Designations Designations { get; set; }

    }
}

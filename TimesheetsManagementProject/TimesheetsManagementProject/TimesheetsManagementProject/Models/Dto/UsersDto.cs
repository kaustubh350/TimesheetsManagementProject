﻿using System.ComponentModel.DataAnnotations;

namespace TimesheetsManagementProject.Models.Dto
{
    public class UsersDto
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

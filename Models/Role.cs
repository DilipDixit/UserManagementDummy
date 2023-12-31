﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementDummy.Models
{
    
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Permissions { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}

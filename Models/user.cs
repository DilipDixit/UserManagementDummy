﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementDummy.Models
{
    public class user
    {
        
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();




       
    }
}

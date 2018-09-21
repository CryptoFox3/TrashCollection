using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageCollection.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public int Zipcode { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
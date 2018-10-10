using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        
        [Key]
        public int CustomerId { get; set; }
        public string Username { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    
        public string Email { get; set; }
        [Display(Name = "Pickup day")]
        public string PickupDay { get; set; }


        [Display(Name = "Full Address")]
        public string Address { get; set; }
        [Display(Name = "Street Number")]
        public int HouseNumber { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }
        [Display(Name = "Amount Due")]
        public double AmountDue { get; set; }
        [Display(Name = "Account on hold")]
        public bool AccountHold { get; set; }
       
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }





        }
    }
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Pickups
    {
        [Key]
        public int PickupId { get; set; }
        [Display(Name = "Pickup day")]
        public string PickupWeekDay {get; set;}
        [Display(Name = "Pickup date")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }
        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }
        [Display(Name = "Repeat pickup")]
        public bool Repeat { get; set; }
        [Display(Name = "Complete")]
        public bool IsCompleted {get; set;}
        [Display(Name = "Complete time")]
        public DateTime CompleteTime {get; set;}
        [Display(Name = "Fee")]
        public double PickupCost { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
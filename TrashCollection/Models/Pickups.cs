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
        public string PickupWeekDay {get; set;}
        public DateTime PickupDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int Zipcode { get; set; }
        public bool Repeat { get; set; }
        public bool IsCompleted {get; set;}
        public double PickupCost { get; set; }
        
    }
}
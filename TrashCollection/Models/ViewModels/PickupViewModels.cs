using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models.ViewModels
{
    public class PickupViewModels
    {
        public Customer Customer { get; set; }
        public Pickups Pickup { get; set; }
        public Pickups OneTimePickup { get; set; }
        public List<Pickups> PickupsList { get; set; }
    }
}
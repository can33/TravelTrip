using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.EntityFramework
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string FullAddress { get; set; }
        public string Mail { get; set; }
        public string Location { get; set; }

    }
}
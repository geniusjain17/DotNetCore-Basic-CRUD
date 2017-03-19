using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSys.Models
{
    public class Vechile
    {
        public int Id { get; set; }
        [Display(Name = "Vechicle Type")]
        public string VechileType { get; set; }
        [Display(Name = "Entry Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
    }
}

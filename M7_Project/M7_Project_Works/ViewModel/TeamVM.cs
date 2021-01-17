using M7_Project_Works.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M7_Project_Works.ViewModel
{
    public class TeamVM
    {
        [Display(Name = "Team ID")]
        public int teamId { get; set; }
        [Display(Name = "Team Name")]
        public string teamName { get; set; }
        [EnumDataType(typeof(Location)), Display(Name = "Region")]
        public Location? Location { get; set; }
        [Display(Name = "Contact No.")]
        public string Contact { get; set; }
        
        [Display(Name = "Established On"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Established { get; set; }
        public int RunningFor { get
            {
                return (DateTime.Now - Established).Days / 365;
            } }
    }
}
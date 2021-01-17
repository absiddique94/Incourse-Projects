using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M7_Project_Works.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),
           Compare("Password"), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
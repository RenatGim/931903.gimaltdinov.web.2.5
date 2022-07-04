﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp2._5.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Full name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter speciallity")]
        [Display(Name = "Speciallity")]
        public string Speciallity { get; set; }




    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   public class EmployeeModel
    {
       
        public int Empid { get; set; }
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(DateTime), "1970 - 01 - 01", "2004 - 01-01")]
        public DateTime DateOfBirth { get; set; }
        public decimal Experience { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$")]

        public long Phonenumber { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }

    }
}

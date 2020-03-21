using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDClinic.Models
{
    public class PatientModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string fname { get; set; }
        [StringLength(50)]
        public string mname { get; set; }
        [StringLength(50)]
        public string lname { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        [StringLength(200)]
        public string Address { get; set; }


        [StringLength(4)]
        public string BloodType { get; set; }


        [StringLength(500)]
        public string Picture { get; set; } = "/images/unkown.jpg";

        public IFormFile pic { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String pat_insurance_company_name { get; set; }

      
    }
}

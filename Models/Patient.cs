using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SDClinic.Models
{
    public class Patient
    {
        [Required]
        public int Id { get; set; }
        
        public string username { get; set; }
        [ForeignKey("username")]
        public  IdentityUser user { get; set; }
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


        [Required]
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String pat_insurance_company_name { get; set; }

        [Required]
        [ForeignKey("pat_insurance_company_name")]
        public InsuranceCompany insurance_company { get; set; }

        public List<Consultation> consultations { get; set; }

        public List<Date> dates { get; set; }



    }
}

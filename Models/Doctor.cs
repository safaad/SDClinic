using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models
{
    public class Doctor
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        public string username { get; set; }
        //[ForeignKey("username")]
        //public IdentityUser user { get; set; }
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string fname { get; set; }
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string mname { get; set; }
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string lname { get; set; }
        [StringLength(10, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")] public string Gender { get; set; }
        public DateTime? Birthday { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public string Address { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length is {1}")]
        public string About { get; set; }


        [StringLength(100)]
        public string Speciality { get; set; }
        [StringLength(100)]
        public string Time { get; set; }
        public List<Assistant> Assistants { get; set; }

        public List<Consultation> consultations { get; set; }

        public List<Date> dates { get; set; }


    }
}

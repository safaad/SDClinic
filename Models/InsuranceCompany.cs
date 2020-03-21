using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models
{
    public class InsuranceCompany
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string username { get; set; }
        //[ForeignKey("username")]
        //public IdentityUser user { get; set; }

        [Required]
        [Key]
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Fax { get; set; }

        public List<Patient> patients { get; set; }
        public List<Report> reports { get; set; }
    }
}

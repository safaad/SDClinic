using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models
{
    public class Admin
    {
        [Required]
        [Key]
        public int Id { get; set; }
      
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string fname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string mname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string lname { get; set; }

        public string username { get; set; }
        //[ForeignKey("username")]
        //public IdentityUser user { get; set; }

    }
}

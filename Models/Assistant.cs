using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SDClinic.Models
{
    public class Assistant
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string username { get; set; }
        //[ForeignKey("username")]
        //public IdentityUser user { get; set; }
        [Required]
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        public int DoctorId { get; set; }


        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string FName { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string MName { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string LName { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SDClinic.Models
{
    public class Messages
    {
        [Required]
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(150)]
        [Required]
        public string Subject { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public string Content { get; set; }
        [Required]
        public DateTime? DateMsg { get; set; }


    }
}

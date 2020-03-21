using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models

{
    public class Date
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime date_dateTime { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models

{
    public class Consultation
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //foreign keys
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
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String Title { get; set; }
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public String Type { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? DateCons { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public String Symptoms { get; set; }
        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public String Diagnoses { get; set; }
        [StringLength(10, ErrorMessage = "Maximum length is {1}")]
        public String Temp { get; set; }
        [StringLength(20, ErrorMessage = "Maximum length is {1}")]
        public String BloodPressure { get; set; }
        [StringLength(20)]
        [Required]
        public String Cost { get; set; }
        [StringLength(100)]
        public String Treatment { get; set; }
        [StringLength(20)]
        public String Insurance_Confirmation { get; set; } = "pending";
        public List<Report> reports { get; set; }




    }
}

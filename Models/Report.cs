using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDClinic.Models

{
    public class Report
    {

        [Key]
        [Required]
        public int Id { get; set; }

        //foreign key
        [Required]
        public int report_cons_id { get; set; }

        [Required]
        [ForeignKey("report_cons_id")]
        public Consultation consultation;

        [Required]
        public string ReportId { get; set; }

        [Required]
        [ForeignKey("ReportId")]
        public InsuranceCompany InsuranceCompany;


    }
}

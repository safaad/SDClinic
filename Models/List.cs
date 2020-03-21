using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SDClinic.Models
{
    public class List
    {
        public int Id { get; set; }
        //foreign keys
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}

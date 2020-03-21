using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SDClinic.Models

{
    public class Reminder_Doctor
    {
        public int Id { get; set; }
        
        public DateTime? DateTime { get; set; }
        [StringLength(300)]
        public string Content { get; set; }
        [StringLength(12)]
        public string Priority { get; set; }
        [StringLength(100)]
        public string Title { get; set; }

        //foreign key
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentDatabase.Models;

namespace StudentDatabase.Models
{
    [Table ("Lecturers")]
    public class Lecturer : IDObject
    {
        
        [Required]
        public string LecturerName { get; set; }
        [Required]
        public string LecturerSurname { get; set; }
        public string? LecturerEmail   { get; set; }
        [StringLength(9)]
        public string? LecturerPhone { get; set; }

    }
}

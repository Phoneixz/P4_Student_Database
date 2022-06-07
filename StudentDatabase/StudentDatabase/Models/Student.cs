using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase.Models
{

    [Table("Student")]
    public class Student : IDObject
    {
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set; }
        [StringLength(9)]
        public string StudentPhone { get; set; }
        [Required]
        public int StudentYear { get; set; }
        [Required]
        public string StudentStatus { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDatabase.Models;

namespace StudentDatabase.Models
{
    [Table ("Grades")]
    public class Grade : IDObject
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }
        [Required]
        public int GradeValue { get; set; }
        [Required]
        public DateTime GradeDate {get; set; }
        public string? GradeName { get; set; }
        [Required]
        public string GradeType { get; set; }
        [Required]
        public virtual ICollection<Student> Students { get; set; }
    }
}

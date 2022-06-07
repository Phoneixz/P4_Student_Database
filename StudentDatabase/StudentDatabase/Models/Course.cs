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
    [Table("Courses")]
    public class Course : IDObject
    {
        public Course()
        {
            Lecturers = new HashSet<Lecturer>();
            Grades = new HashSet<Grade>();
            Students = new HashSet<Student>();
        }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseDesc { get; set; }
        [Required]
        public string CourseType {get; set; }
        [Required]
        public int CourseLength { get; set; }
        [Required]
        public string CourseStatus { get; set; }
        [Required]
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
    }
}

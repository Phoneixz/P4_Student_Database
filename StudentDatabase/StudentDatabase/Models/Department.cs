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
    [Table("Departments")]
    public class Department : IDObject
    {
        public Department()
        {
            Lecturers = new HashSet<Lecturer>();
        }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string DepartmentSupervisor { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}

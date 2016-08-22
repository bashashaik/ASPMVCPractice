using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class Employee
    {
        public int EmployeeId { set; get; }
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Gender { set; get; }
        [Required]
        public string City { set; get; }
        [Required]
        public DateTime DateOfBirth { set; get; }

        public int DepartmentId { set; get; }
    }
}

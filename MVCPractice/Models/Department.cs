using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
}
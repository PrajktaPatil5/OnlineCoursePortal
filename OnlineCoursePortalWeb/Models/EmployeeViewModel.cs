using System.ComponentModel.DataAnnotations;

namespace OnlineCoursePortalWeb.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Models
{
    public class ApplicationUser
    {
       
        
        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(20, ErrorMessage = "User Name cannot exceed 20 characters.")]
        public string Name { get; set; }

        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}

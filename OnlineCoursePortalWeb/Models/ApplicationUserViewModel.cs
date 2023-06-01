using System.ComponentModel.DataAnnotations;

namespace OnlineCoursePortalWeb.Models
{
   
        public class ApplicationUserViewModel
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

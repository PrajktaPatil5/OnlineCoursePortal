using System.ComponentModel.DataAnnotations;

namespace OnlineCoursePortalWeb.Models
{
   
        public class CourseBookingViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "CourseId is required.")]
            public int CourseId { get; set; }

            [Required(ErrorMessage = "StudentId is required.")]
            public string UserEmail { get; set; }
        
            public string IsApproved { get; set; }
        }
    
}

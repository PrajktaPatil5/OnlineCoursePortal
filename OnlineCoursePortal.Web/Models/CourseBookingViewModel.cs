using System.ComponentModel.DataAnnotations;

namespace OnlineCoursePortal.Web.Models
{
    public class CourseBookingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "StudentId is required.")]
        public string StudentId { get; set; }
        public string IsApproved { get; set; }
    }
}

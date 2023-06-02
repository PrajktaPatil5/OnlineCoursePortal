using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Models
{
    public class CourseBooking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "UserEmail is required.")]
        public string UserEmail { get; set; }

        
     
       
        public string IsApproved { get; set; }

    }
}

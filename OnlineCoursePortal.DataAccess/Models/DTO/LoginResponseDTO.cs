using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Models.DTO
{
    public class LoginResponseDTO
    {
        public ApplicationUser ApplicationUser { get; set; }
       
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Models.DTO
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

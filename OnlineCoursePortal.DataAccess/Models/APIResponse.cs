﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Models
{
    public class APIResponse
    {
   
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> Errormessages { get; set; }
        
        public object Result { get; set; }
    }
}

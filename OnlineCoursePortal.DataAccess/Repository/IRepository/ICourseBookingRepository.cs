using OnlineCoursePortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository.IRepository
{
    public interface ICourseBookingRepository
    {
        public void Create(CourseBooking CourseBooking);
        public IEnumerable<CourseBooking> Get();
        public void Update(CourseBooking CourseBooking);
        public void Delete(int Id);
        public void Save();
    }
}

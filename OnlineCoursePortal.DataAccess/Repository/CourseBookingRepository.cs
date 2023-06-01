using Microsoft.EntityFrameworkCore;
using OnlineCoursePortal.DataAccess.Data;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository
{
    public class CourseBookingRepository : ICourseBookingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;


        public CourseBookingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(CourseBooking CourseBooking)
        {
            _applicationDbContext.CourseBookings.Add(CourseBooking);
        }

        

        public void Delete(int Id)
        {
            var courseBooking = _applicationDbContext.CourseBookings.Find(Id);
            if (courseBooking != null)
            {
                _applicationDbContext.CourseBookings.Remove(courseBooking);
            }
        }

        public IEnumerable<CourseBooking> Get()
        {
            return _applicationDbContext.CourseBookings.ToList();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(CourseBooking courseBooking )
        {
            _applicationDbContext.Entry(courseBooking).State = EntityState.Modified;
        }

       
    }
}

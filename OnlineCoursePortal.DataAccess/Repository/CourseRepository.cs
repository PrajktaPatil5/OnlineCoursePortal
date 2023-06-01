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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;


        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public void Create(Course Course)
        {
            _applicationDbContext.Courses.Add(Course);

        }

        public void Delete(int Id)
        {
            var Course = _applicationDbContext.Courses.Find(Id);
            if (Course != null)
            {
                _applicationDbContext.Courses.Remove(Course);
            }
        }

        public IEnumerable<Course> Get()
        {
            return _applicationDbContext.Courses.ToList();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Course Course)
        {
            _applicationDbContext.Entry(Course).State = EntityState.Modified;
        }
    }
}

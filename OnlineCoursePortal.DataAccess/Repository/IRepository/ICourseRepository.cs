using OnlineCoursePortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository.IRepository
{
    public interface ICourseRepository
    {
        public void Create(Course Course);
        public IEnumerable<Course> Get();
        public void Update(Course Course);
        public void Delete(int Id);
        public void Save();
    }
}

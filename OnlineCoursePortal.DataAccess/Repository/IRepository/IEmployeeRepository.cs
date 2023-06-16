using OnlineCoursePortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        public void Create(Employee Employee);
        public IEnumerable<Employee> Get();
        public void Update(Employee Employee);
        public void Delete(int Id);
        public void Save();
    }
}

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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;


        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(Employee Employee)
        {
            _applicationDbContext.Employees.Add(Employee);
        }

        public void Delete(int Id)
        {
            var Employee = _applicationDbContext.Employees.Find(Id);
            if (Employee != null)
            {
                _applicationDbContext.Employees.Remove(Employee);
            }
        }

        public IEnumerable<Employee> Get()
        {
            return _applicationDbContext.Employees.ToList();
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(Employee Employee)
        {
            _applicationDbContext.Entry(Employee).State = EntityState.Modified;
          //  _applicationDbContext.Employees.Update()
        }
    }
}

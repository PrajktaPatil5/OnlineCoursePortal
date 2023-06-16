using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface IEmployeeService
    {
       Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>( EmployeeViewModel employeeViewModel );
    }
}

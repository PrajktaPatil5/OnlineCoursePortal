using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface ICourseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(CourseViewModel courseViewModel);

        Task<T> UpdateAsync<T>(CourseViewModel courseViewModel);

        Task<T> DeleteAsync<T>(int id);
        Task<T> Getbyid<T>(int id);
    }
}

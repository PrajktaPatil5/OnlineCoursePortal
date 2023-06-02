using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface ICourseBookingService
    {
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(CourseBookingViewModel courseBookingViewModel);

        //Task<T> UpdateAsync<T>(CourseBookingViewModel courseBookingViewModel);

        Task<T> DeleteAsync<T>(int id);
        Task<T> Getbyid<T>(int id);
        Task<T> Updatebyid<T>(int id);
        Task<T> UpdatebyidReject<T>(int id);
    }
}

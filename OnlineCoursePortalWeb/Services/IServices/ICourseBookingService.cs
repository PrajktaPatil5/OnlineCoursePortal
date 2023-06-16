using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface ICourseBookingService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(CourseBookingViewModel courseBookingViewModel, string token);

        //Task<T> UpdateAsync<T>(CourseBookingViewModel courseBookingViewModel);

        Task<T> DeleteAsync<T>(int id, string token);
        Task<T> Getbyid<T>(int id, string token);
        Task<T> Updatebyid<T>(int id, string token);
        Task<T> UpdatebyidReject<T>(int id, string token);
    }
}

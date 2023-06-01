using OnlineCoursePortal.Web.Models;

namespace OnlineCoursePortal.Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}

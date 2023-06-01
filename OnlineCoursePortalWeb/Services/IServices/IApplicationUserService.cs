using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface IApplicationUserService
    {

        Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel);
        Task<T> RegisterAsync<T>(ApplicationUserViewModel applicationUserViewModel);
        Task<T> Getbyid<T>(string Email);
    }
}

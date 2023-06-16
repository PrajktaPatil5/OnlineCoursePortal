using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using System.Security.Policy;

namespace OnlineCoursePortalWeb.Services
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string CourseBookingUrl;
        public ApplicationUserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            CourseBookingUrl = configuration.GetValue<string>("ServiceUrls:Course");

        }

        public Task<T> Getbyid<T>(string Email)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = CourseBookingUrl + "/api/ApplicationUser/" + Email,
                ApiType = "GET"
            });
        }

        public Task<T> LoginAsync<T>(LoginRequestViewModel loginRequestViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = CourseBookingUrl + "/api/ApplicationUser/login",
                ApiType = "POST",
                Data = loginRequestViewModel
            });
        }

        public Task<T> RegisterAsync<T>(ApplicationUserViewModel applicationUserViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                Url = CourseBookingUrl + "/api/ApplicationUser/register",
                ApiType = "POST",
                Data = applicationUserViewModel
            });
            
        }
    }
}


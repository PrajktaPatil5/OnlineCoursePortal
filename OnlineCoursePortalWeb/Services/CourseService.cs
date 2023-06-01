using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;

namespace OnlineCoursePortalWeb.Services
{
    public class CourseService : BaseService, ICourseService

    {
        private readonly IHttpClientFactory _clientFactory;
        private string courseUrl;
        public CourseService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            courseUrl = configuration.GetValue<string>("ServiceUrls:Course");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                
                Url = courseUrl + "/api/Course"

            });
        }

        public Task<T> CreateAsync<T>(CourseViewModel courseViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "POST",
                Data = courseViewModel,
                Url = courseUrl + "/api/Course"
                
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "DELETE",
                Url = courseUrl + "/api/Course/"+ id
               
            });
        }

        public Task<T> UpdateAsync<T>(CourseViewModel courseViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "PUT",
              
                Url = courseUrl + "/api/Course",
                Data = courseViewModel
            });
        }

        public Task<T> Getbyid<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                Url = courseUrl + "/api/Course/" + id,

            });
        }
    }
}

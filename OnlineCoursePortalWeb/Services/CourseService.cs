using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Task<T> GetAllAsync<T>(string token)
        {
            
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                
                Url = courseUrl + "/api/Course",
                Token = token

        });
        }

        public Task<T> CreateAsync<T>(CourseViewModel courseViewModel, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "POST",
                Data = courseViewModel,
                Url = courseUrl + "/api/Course",
                Token = token
                
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "DELETE",
                Url = courseUrl + "/api/Course/"+ id,
                Token = token
               
            });
        }

        public Task<T> UpdateAsync<T>(CourseViewModel courseViewModel, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "PUT",
              
                Url = courseUrl + "/api/Course",
                Data = courseViewModel,
                Token = token
            });
        }

        public Task<T> Getbyid<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                Url = courseUrl + "/api/Course/" + id,
                Token = token

            });
        }
    }
}

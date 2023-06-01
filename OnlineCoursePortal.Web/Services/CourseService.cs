using Newtonsoft.Json.Linq;
using OnlineCoursePortal.Web.Models;
using OnlineCoursePortal.Web.Services.IServices;

namespace OnlineCoursePortal.Web.Services
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
    }
}

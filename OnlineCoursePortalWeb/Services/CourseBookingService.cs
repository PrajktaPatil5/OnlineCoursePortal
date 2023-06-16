using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;

namespace OnlineCoursePortalWeb.Services
{
    public class CourseBookingService : BaseService, ICourseBookingService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string courseBookingUrl;
        public CourseBookingService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            courseBookingUrl = configuration.GetValue<string>("ServiceUrls:Course");
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",

                Url = courseBookingUrl + "/api/CourseBooking",
                   Token = token

            });
        }

        public Task<T> CreateAsync<T>(CourseBookingViewModel courseBookingViewModel, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "POST",
               
                Url = courseBookingUrl + "/api/CourseBooking",
                Data = courseBookingViewModel,
                Token = token

            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "DELETE",
                Url = courseBookingUrl + "/api/CourseBooking/" + id,
                Token = token
                


            });
        }

       

        public Task<T> Getbyid<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",
                Url = courseBookingUrl + "/api/CourseBooking/" + id,
                Token = token

            });
        }

        public Task<T> UpdateAsync<T>(CourseBookingViewModel courseBookingViewModel)
        {
            throw new NotImplementedException();
            
        }

        public Task<T> Updatebyid<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "PUT",
                Url = courseBookingUrl + "/api/CourseBooking/Approve/" + id,
                Token = token
            }
                );
        }

        public Task<T> UpdatebyidReject<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "PUT",
                Url = courseBookingUrl + "/api/CourseBooking/Reject/" + id,
                Token = token
            }
                );


        }
    }

}


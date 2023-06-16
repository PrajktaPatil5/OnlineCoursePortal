using AutoMapper;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineCoursePortalWeb.Services
{
    public class CourseBookingService : BaseService, ICourseBookingService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string courseBookingUrl;
        private readonly IMapper _mapper;
        public CourseBookingService(IHttpClientFactory clientFactory, IConfiguration configuration, IMapper mapper ) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
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
            var data = _mapper.Map<CourseBooking>(courseBookingViewModel);
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "POST",
                Url = courseBookingUrl + "/api/CourseBooking",
                Data = data,
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


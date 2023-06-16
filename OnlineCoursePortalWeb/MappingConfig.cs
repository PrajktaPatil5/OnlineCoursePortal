using AutoMapper;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb
{
    public class MappingConfig : Profile

    {
        public MappingConfig()
        {
            CreateMap<Course, CourseViewModel >().ReverseMap();
            CreateMap<CourseBooking, CourseBookingViewModel>().ReverseMap();
        }
        }
}

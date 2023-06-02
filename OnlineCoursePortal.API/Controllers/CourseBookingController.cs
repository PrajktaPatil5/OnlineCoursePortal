using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursePortal.DataAccess.Data;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Repository;
using OnlineCoursePortal.DataAccess.Repository.IRepository;
using System.Data;

namespace OnlineCoursePortal.API.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseBookingController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICourseBookingRepository _courseBookingRepository;
        private readonly ICourseRepository _courseRepository;
        protected APIResponse _APIResponse;


        public CourseBookingController(ApplicationDbContext applicationDbContext, ICourseBookingRepository courseBookingRepository,ICourseRepository courseRepository)
        {
            _applicationDbContext = applicationDbContext;
            _courseBookingRepository = courseBookingRepository;
            _courseRepository = courseRepository;
            this._APIResponse = new APIResponse();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _courseBookingRepository.Get();
            var pendingdata = result.Where(x => x.IsApproved == "Pending");
            _APIResponse.Result = pendingdata;
            return Ok(_APIResponse);
        }
        [HttpPost]
        public IActionResult Create(CourseBooking courseBooking)
        {
         
            _courseBookingRepository.Create(courseBooking);
            _courseBookingRepository.Save();
            var data = _applicationDbContext.Courses.Find(courseBooking.CourseId);
            data.AvailableSeats = data.AvailableSeats - 1;
            _courseRepository.Update(data);
            _courseRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(CourseBooking courseBooking)
        {
            _courseBookingRepository.Update(courseBooking);
            _courseBookingRepository.Save();
            return Ok();
        }
        //[Authorize(Roles = "admin")]

        [HttpDelete("{Id:int}")]
        public IActionResult Delete(int Id)
        {
            _courseBookingRepository.Delete(Id);
            _courseBookingRepository.Save();
            return Ok();
        }


        [HttpGet("{id:int}")]
        public IActionResult Getbyid(int id)
        {
            var data = _applicationDbContext.CourseBookings.Find(id);
            _APIResponse.Result = data;
            return Ok(_APIResponse);
        }

        [HttpPut("Approve/{id:int}")]
        public IActionResult Updatebyid(int id)
        {
            var data = _applicationDbContext.CourseBookings.Find(id);
            data.IsApproved = "Approved";
            _courseBookingRepository.Update(data);
            _courseBookingRepository.Save();
            return Ok();


        }

        [HttpPut("Reject/{id:int}")]
        public IActionResult UpdatebyidReject(int id)
        {
            var data = _applicationDbContext.CourseBookings.Find(id);
            data.IsApproved = "Rejected";
            _courseBookingRepository.Update(data);
            _courseBookingRepository.Save();
            var data1 = _applicationDbContext.Courses.Find(data.CourseId);
            data1.AvailableSeats = data1.AvailableSeats + 1;
            _courseRepository.Update(data1);
            _courseRepository.Save();
            return Ok();


        }
    }

}

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
        protected APIResponse _APIResponse;


        public CourseBookingController(ApplicationDbContext applicationDbContext, ICourseBookingRepository courseBookingRepository)
        {
            _applicationDbContext = applicationDbContext;
            _courseBookingRepository = courseBookingRepository;
            this._APIResponse = new APIResponse();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _courseBookingRepository.Get();
            _APIResponse.Result = result;
            return Ok(_APIResponse);
        }
        [HttpPost]
        public IActionResult Create(CourseBooking courseBooking)
        {

            _courseBookingRepository.Create(courseBooking);
            _courseBookingRepository.Save();
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
    }

}

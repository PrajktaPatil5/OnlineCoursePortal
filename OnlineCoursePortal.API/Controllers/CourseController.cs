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
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICourseRepository _courseRepository;
        protected APIResponse _APIResponse;

        public CourseController(ApplicationDbContext applicationDbContext, ICourseRepository courseRepository)
        {
            _applicationDbContext = applicationDbContext;
            _courseRepository = courseRepository;
            this._APIResponse = new APIResponse();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _courseRepository.Get();
            _APIResponse.Result = result;
            return Ok(_APIResponse);
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            _courseRepository.Create(course);
            _courseRepository.Save();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Course course)
        {
            _courseRepository.Update(course);
            _courseRepository.Save();
            return Ok();
        }
        [HttpDelete("{Id:int}")]
       
        public IActionResult Delete(int Id)
        {
            _courseRepository.Delete(Id);
            _courseRepository.Save();
            return Ok();
        }
        [HttpGet("{Id:int}")]
        public IActionResult Getbyid(int Id)
        {
           var data= _applicationDbContext.Courses.Find(Id);
            _APIResponse.Result = data;
            return Ok(_APIResponse);
        }
    }
}

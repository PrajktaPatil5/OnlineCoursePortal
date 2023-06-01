using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineCoursePortal.Web.Models;
using OnlineCoursePortal.Web.Services.IServices;

namespace OnlineCoursePortal.Web.Controllers
{
    public class CourseController : Controller
    {
       
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            List<CourseViewModel> list = new();

            var response = await _courseService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
    }


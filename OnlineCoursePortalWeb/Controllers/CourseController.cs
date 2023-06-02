using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using System.Data;

namespace OnlineCoursePortalWeb.Controllers
{
    //[Area("Admin")]
    [Authorize]
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

       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {

            return View();
        }

       // [Authorize(Roles = "admin")]
        //[HttpPost]
        
        public async Task<IActionResult> CreateCourse(CourseViewModel courseViewModel)
        {

            var response = await _courseService.CreateAsync<APIResponse>(courseViewModel);


            return RedirectToAction(nameof(Index));

        }


       // [Authorize(Roles = "admin")]
        public IActionResult update(int id)
        {

            var response = _courseService.Getbyid<APIResponse>(id);
            var data = Convert.ToString(response.Result.Result);
            if (response != null)
            {
                CourseViewModel courseViewModel = JsonConvert.DeserializeObject<CourseViewModel>(data);
                return View(courseViewModel);
            }


            return View();
        }

       // [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(CourseViewModel courseViewModel)
        {
            await _courseService.UpdateAsync<APIResponse>(courseViewModel);
            return RedirectToAction("Index");
        }

        
        
      //  [HttpDelete]
       
      // [Authorize(Roles = "admin")]
      public async Task<ActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync<APIResponse>(id);
            return RedirectToAction("Index");
        }
        //public async Task<ActionResult> Details()
        //{

        //}
    }
}


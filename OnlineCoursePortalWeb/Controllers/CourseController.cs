using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using System.Data;
using Token = OnlineCoursePortalWeb.Models.Token;

namespace OnlineCoursePortalWeb.Controllers
{
    
  
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<CourseViewModel> list = new();
            string token = HttpContext.Session.GetString(Token.SessionToken);
            var response = await _courseService.GetAllAsync<APIResponse>(token);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "ApplicationUser")]
        public async Task<IActionResult> Create()
        {

            return View();
        }

       [Authorize(Roles = "ApplicationUser")]
        
        public async Task<IActionResult> CreateCourse(CourseViewModel courseViewModel)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);

            var response = await _courseService.CreateAsync<APIResponse>(courseViewModel, token);
            TempData["success"] = "course created successfully";


            return RedirectToAction(nameof(Index));

        }


        [Authorize(Roles = "ApplicationUser")]
        public IActionResult update(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            var response = _courseService.Getbyid<APIResponse>(id,token);

            var data = Convert.ToString(response.Result.Result);
            if (response != null)
            {
                CourseViewModel courseViewModel = JsonConvert.DeserializeObject<CourseViewModel>(data);
                return View(courseViewModel);
            }
           

            return View();
        }

        [Authorize]
        public async Task<ActionResult> Edit(CourseViewModel courseViewModel)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            await _courseService.UpdateAsync<APIResponse>(courseViewModel, token);
            TempData["success"] = "course Updated successfully";
            return RedirectToAction("Index");
        }

        
        
      
       
     
        #region API CALLS

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            List<CourseViewModel> objProductList = new();

            var response = await _courseService.GetAllAsync<APIResponse>(token);
            if (response != null && response.IsSuccess)
            {
                objProductList = JsonConvert.DeserializeObject<List<CourseViewModel>>(Convert.ToString(response.Result));
            }
            
            return Json(new { data = objProductList });
        }

        [Authorize(Roles = "ApplicationUser")]
        public async Task<ActionResult> Delete(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            await _courseService.DeleteAsync<APIResponse>(id, token);
            TempData["success"] = "course Deleted successfully";
            return RedirectToAction("Index");
        }

        #endregion
    }
}


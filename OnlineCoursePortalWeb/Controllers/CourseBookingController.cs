using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services;
using OnlineCoursePortalWeb.Services.IServices;
using System.Data;

namespace OnlineCoursePortalWeb.Controllers
{
   
    
    public class CourseBookingController : Controller
    {
        private readonly ICourseBookingService _courseBookingService;
        private readonly ICourseService _courseService;
        private readonly IApplicationUserService _applicationUserService;

        public CourseBookingController(ICourseBookingService courseBookingService,ICourseService courseService,IApplicationUserService applicationUserService)
        {
            _courseBookingService = courseBookingService;
            _courseService = courseService;
           _applicationUserService = applicationUserService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            List<CourseBookingViewModel> list = new();

            var response = await _courseBookingService.GetAllAsync<APIResponse>(token);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseBookingViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [Authorize(Roles = "ApplicationUser")]
        public async Task<IActionResult> Create(int CourseId)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            TempData["CourseId"] = CourseId;
            return View();
        }

        [Authorize(Roles = "ApplicationUser")]
        [HttpPost]
        
        public async Task<IActionResult> CreateCourseBooking(CourseBookingViewModel courseBookingViewModel)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            courseBookingViewModel.IsApproved = "Pending";
            courseBookingViewModel.UserEmail = User.Identity.Name;
            courseBookingViewModel.CourseId = Convert.ToInt32(TempData["CourseId"]);


            var response = await _courseBookingService.CreateAsync<APIResponse>(courseBookingViewModel, token);
            TempData["success"] = "coursebooking Created successfully";

            return RedirectToAction(nameof(Index));
        }



        [HttpDelete]

        [Authorize(Roles = "ApplicationUser")]
        public async Task<ActionResult> Delete(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            await _courseBookingService.DeleteAsync<APIResponse>(id, token);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Updatebyid(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            await _courseBookingService.Updatebyid<APIResponse>(id,token);
            TempData["success"] = "coursebooking Approved successfully";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdatebyidReject(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);
            await _courseBookingService.UpdatebyidReject<APIResponse>(id, token);
            TempData["success"] = "coursebooking Rejected successfully";
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<ActionResult> Details(int id)
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);

            ViewData["Bookid"] = id;
            CourseBookingViewModel data=new CourseBookingViewModel();
            ApplicationUserViewModel data1= new ApplicationUserViewModel();
            CourseViewModel data2 = new CourseViewModel();
          
            var response=   _courseBookingService.Getbyid<APIResponse>(id,token);

            if(response != null)
            {
                data = JsonConvert.DeserializeObject<CourseBookingViewModel>(Convert.ToString(response.Result.Result));
            }
           var response2 = _applicationUserService.Getbyid<APIResponse>(data.UserEmail);

            if(response2 != null)
            {
                data1 = JsonConvert.DeserializeObject<ApplicationUserViewModel>(Convert.ToString(response2.Result.Result));
            }
           
            var response3 = _courseService.Getbyid<APIResponse>(data.CourseId,token);

            if(response3 != null)
            {
                data2 = JsonConvert.DeserializeObject<CourseViewModel>(Convert.ToString(response3.Result.Result));
            }
            DetailsOfBooking detailsOfBooking = new DetailsOfBooking()
            {
                ApplicationUserViewModel = data1,
                Course = data2
            };


            return View(detailsOfBooking);
        }
    }
}


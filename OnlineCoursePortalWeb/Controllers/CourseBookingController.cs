using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services;
using OnlineCoursePortalWeb.Services.IServices;
using System.Data;

namespace OnlineCoursePortalWeb.Controllers
{
    //[Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> Index()
        {
            List<CourseBookingViewModel> list = new();

            var response = await _courseBookingService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseBookingViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(int CourseId)
        {
            TempData["CourseId"] = CourseId;
            return View();
        }

       // [Authorize(Roles = "admin")]
       [HttpPost]
        
        public async Task<IActionResult> CreateCourseBooking(CourseBookingViewModel courseBookingViewModel)
        {
            courseBookingViewModel.IsApproved = "Pending";
            
            courseBookingViewModel.CourseId = Convert.ToInt32(TempData["CourseId"]);


            var response = await _courseBookingService.CreateAsync<APIResponse>(courseBookingViewModel);


            return RedirectToAction(nameof(Index));
        }



        [HttpDelete]

       // [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _courseBookingService.DeleteAsync<APIResponse>(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Updatebyid(int id)
        {
            await _courseBookingService.Updatebyid<APIResponse>(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdatebyidReject(int id)
        {
            await _courseBookingService.UpdatebyidReject<APIResponse>(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Details(int id)
        {

            ViewData["Bookid"] = id;
            CourseBookingViewModel data=new CourseBookingViewModel();
            ApplicationUserViewModel data1= new ApplicationUserViewModel();
            CourseViewModel data2 = new CourseViewModel();
         var response=   _courseBookingService.Getbyid<APIResponse>(id);

            if(response != null)
            {
                data = JsonConvert.DeserializeObject<CourseBookingViewModel>(Convert.ToString(response.Result.Result));
            }
           var response2 = _applicationUserService.Getbyid<APIResponse>(data.UserEmail);

            if(response2 != null)
            {
                data1 = JsonConvert.DeserializeObject<ApplicationUserViewModel>(Convert.ToString(response2.Result.Result));
            }
          var response3 = _courseService.Getbyid<APIResponse>(data.CourseId);

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


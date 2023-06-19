using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;
using APIResponse = OnlineCoursePortalWeb.Models.APIResponse;

namespace OnlineCoursePortalWeb.ViewComponents
{
    public class CountdownViewComponent : ViewComponent
    {
        private readonly ICourseService _courseService;

        public CountdownViewComponent(ICourseService courseService)
        {
            _courseService = courseService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string token = HttpContext.Session.GetString(Token.SessionToken);

            var courses = await _courseService.GetAllAsync<APIResponse>(token);


            List<Course> model = JsonConvert.DeserializeObject<List<Course>>(Convert.ToString(courses.Result));




            Course firstEvent = model.OrderBy(e => e.EndDate).FirstOrDefault();

            if (firstEvent != null)
            {
                var countdownTime =  firstEvent.EndDate - DateTime.UtcNow;
                
                return View("Default", countdownTime);
            }

            return Content("No courses found.");
        }

    }
}

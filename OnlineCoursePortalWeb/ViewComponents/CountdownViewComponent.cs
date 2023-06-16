using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortalWeb.Services.IServices;

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

            var courses = await _courseService.GetAllAsync<APIResponse>();


            List<Course> model = JsonConvert.DeserializeObject<List<Course>>(Convert.ToString(courses.Result));




            Course firstEvent = model.OrderBy(e => e.StartDate).FirstOrDefault();

            if (firstEvent != null)
            {
                var countdownTime = firstEvent.StartDate - DateTime.UtcNow;
                
                return View("Default", countdownTime);
            }

            return Content("No courses found.");
        }

    }
}

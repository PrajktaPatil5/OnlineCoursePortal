using Microsoft.AspNetCore.Mvc;
using OnlineCoursePortalWeb.Services.IServices;

namespace OnlineCoursePortalWeb.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
    }
}

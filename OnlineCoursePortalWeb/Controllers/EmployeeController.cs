using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services;
using OnlineCoursePortalWeb.Services.IServices;

namespace OnlineCoursePortalWeb.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> list = new();

            var response = await _employeeService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

       
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel employeeViewModel)
        {

            var response = await _employeeService.CreateAsync<APIResponse>(employeeViewModel);
            TempData["success"] = "Employee created successfully";


            return RedirectToAction(nameof(Index));

        }
    }
}

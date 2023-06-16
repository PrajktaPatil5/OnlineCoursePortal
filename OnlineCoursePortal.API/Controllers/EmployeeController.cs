using Microsoft.AspNetCore.Mvc;
using OnlineCoursePortal.DataAccess.Data;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Repository.IRepository;

namespace OnlineCoursePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEmployeeRepository _employeeRepository;
        protected APIResponse _APIResponse;

            public EmployeeController(ApplicationDbContext applicationDbContext, IEmployeeRepository employeeRepository)
        {
            _applicationDbContext = applicationDbContext;
            _employeeRepository = employeeRepository;
            _APIResponse = new APIResponse();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeRepository.Get();
            _APIResponse.Result = result;
            return Ok(_APIResponse);
        }

        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            _employeeRepository.Create(employee);
            _employeeRepository.Save();
            return Ok();
        }
    }
}

using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursePortal.DataAccess.Data;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Models.DTO;
using OnlineCoursePortal.DataAccess.Repository.IRepository;
using System.Data;
using System.Net;

namespace OnlineCoursePortal.API.Controllers

    
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IApplicationUserRepository _applicationUserRepository;
        protected APIResponse _response;


        public ApplicationUserController(ApplicationDbContext applicationDbContext, IApplicationUserRepository applicationUserRepository)
        {
            _applicationDbContext = applicationDbContext;
            _applicationUserRepository = applicationUserRepository;
            _response = new();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _applicationUserRepository.Get();
            return Ok(result);
        }
        //[HttpPost]
        //public IActionResult Create(ApplicationUser applicationUser)
        //{

        //    _applicationUserRepository.Create(applicationUser);
        //    _applicationUserRepository.Save();
        //    return Ok();
        //}
        [HttpPut]
        public IActionResult Update(ApplicationUser applicationUser)
        {
            _applicationUserRepository.Update(applicationUser);
            _applicationUserRepository.Save();
            return Ok();
        }
        [HttpDelete]
      //  [Authorize(Roles = "admin")]
       
        public IActionResult Delete(string Email)
        {
            _applicationUserRepository.Delete(Email);
            _applicationUserRepository.Save();
            return Ok(_applicationUserRepository.Get());
        }

        [HttpGet("{Email}")]
        public IActionResult Getbyid(string Email)
        {
            var data = _applicationDbContext.ApplicationUsers.Find(Email);
            _response.Result = data;
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _applicationUserRepository.Login(model);
          
            if (loginResponse.ApplicationUser == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errormessages.Add("Username or Password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ApplicationUser model)
        {
            bool ifUserNameUnique = _applicationUserRepository.IsUniqueUser(model.Name);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                // _response.Errormessages.Add("Username already exits");
                _response.Errormessages.Add("Username already exits");
                return BadRequest(_response);
            }

            var user = await _applicationUserRepository.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Errormessages.Add("Error while registering");
                return BadRequest(_response);

            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}


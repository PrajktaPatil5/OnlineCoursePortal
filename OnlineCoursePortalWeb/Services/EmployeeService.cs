using OnlineCoursePortalWeb.Models;
using OnlineCoursePortalWeb.Services.IServices;

namespace OnlineCoursePortalWeb.Services
{
    public class EmployeeService : BaseService, IEmployeeService

    {
        private readonly IHttpClientFactory _clientFactory;
        private string employeeUrl;
        public EmployeeService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            employeeUrl = configuration.GetValue<string>("ServiceUrls:Course");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "GET",

                Url = employeeUrl + "/api/Employee"

            });
        }

        public Task<T> CreateAsync<T>(EmployeeViewModel employeeViewModel)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "POST",
                Data = employeeViewModel,
                Url = employeeUrl + "/api/Employee"

            });
        }

    }
}

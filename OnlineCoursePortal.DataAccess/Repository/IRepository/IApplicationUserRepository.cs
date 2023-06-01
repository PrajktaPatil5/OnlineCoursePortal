using Microsoft.Extensions.Logging;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
       // public void Create(ApplicationUser ApplicationUser);
        public IEnumerable<ApplicationUser> Get();
        public void Update(ApplicationUser ApplicationUser);
        public void Delete(string Email);
        public void Save();

        bool IsUniqueUser(string Email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<ApplicationUser> Register(ApplicationUser applicationUser);
    }
}

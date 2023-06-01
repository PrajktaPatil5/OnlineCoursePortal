using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineCoursePortal.DataAccess.Data;
using OnlineCoursePortal.DataAccess.Models;
using OnlineCoursePortal.DataAccess.Models.DTO;
using OnlineCoursePortal.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private string secretKey;
    


        public ApplicationUserRepository(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            
        }

        public bool IsUniqueUser(string Email)
        {
            var applicationUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Email == Email);
            if (applicationUser == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var applicationUser = _applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == loginRequestDTO.UserName.ToLower());
            if (applicationUser == null)
            {
                return new LoginResponseDTO
                {
                    Token = "",
                    ApplicationUser = null
                };

            }

            //if user was found generate JWT Token
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, applicationUser.Email.ToString()),
                     new Claim(ClaimTypes.Role, applicationUser.Role.ToString())


                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                ApplicationUser = applicationUser
                
            };
            return loginResponseDTO;

        }

        public async Task<ApplicationUser> Register(ApplicationUser applicationUser)
        {
            
            _applicationDbContext.ApplicationUsers.Add(applicationUser);
            await _applicationDbContext.SaveChangesAsync();
            applicationUser.Password = "";
            return applicationUser;


            
           
          
           


        }
        //public void Create(ApplicationUser ApplicationUser)
        //{
        //    _applicationDbContext.ApplicationUsers.Add(ApplicationUser);
        //}

        public void Delete(string Email )
        {
            var applicationUser = _applicationDbContext.ApplicationUsers.Find(Email);
            if (applicationUser != null)
            {
                _applicationDbContext.ApplicationUsers.Remove(applicationUser);
            }
        }

        public IEnumerable<ApplicationUser> Get()
        {
            return _applicationDbContext.ApplicationUsers.ToList();
        }

       

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(ApplicationUser ApplicationUser)
        {
            _applicationDbContext.Entry(ApplicationUser).State = EntityState.Modified;
        }
    }
}

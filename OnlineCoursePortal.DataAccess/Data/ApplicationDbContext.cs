using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCoursePortal.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursePortal.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseBooking> CourseBookings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}

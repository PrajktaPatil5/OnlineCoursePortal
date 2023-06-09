﻿using OnlineCoursePortalWeb.Models;

namespace OnlineCoursePortalWeb.Services.IServices
{
    public interface ICourseService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> CreateAsync<T>(CourseViewModel courseViewModel, string token);

        Task<T> UpdateAsync<T>(CourseViewModel courseViewModel, string token);

        Task<T> DeleteAsync<T>(int id, string token);
        Task<T> Getbyid<T>(int id, string token);
        
        //Task<T> GetAllAsync<T>();
    }
}

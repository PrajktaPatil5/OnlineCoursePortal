namespace OnlineCoursePortal.Web.Services.IServices
{
    public interface ICourseService
    {
        
        Task<T> GetAllAsync<T>();
        
    }
}

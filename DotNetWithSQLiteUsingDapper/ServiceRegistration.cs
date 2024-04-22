using DotNetWithSQLiteUsingDapper.DbServices;
using DotNetWithSQLiteUsingDapper.Services;

namespace DotNetWithSQLiteUsingDapper
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // configure DI for application services
            //services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();
        }
    }

}

using UserManagement.Persistence.DBContext;
using UserManagement.Repository;
using UserManagement.Repository.Interface;

namespace UserManagement.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<UsersDBContext>();
            services.AddTransient<IUserRepository,UserRepository>();
            return services;
        }
    }
}

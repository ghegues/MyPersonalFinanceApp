using Microsoft.EntityFrameworkCore;
using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Application.Services;
using MyPersonalFinanceApp.Application.Utils;
using MyPersonalFinanceApp.Infra.Data;
using MyPersonalFinanceApp.Infra.Interfaces;
using MyPersonalFinanceApp.Infra.Repositories;
using MyPersonalFinanceApp.JWT.Interfaces;
using MyPersonalFinanceApp.JWT.JWTService;

namespace MyPersonalFinanceApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<PasswordHasher>();

            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            return services;
        }
    }
}
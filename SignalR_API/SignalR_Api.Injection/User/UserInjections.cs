using Microsoft.Extensions.DependencyInjection;
using SignalR_Domains.Users;
using SignalR_Repositories.User;
using SignalR_Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Api.Injection.User
{
    public static class UserInjections
    {
        public static IServiceCollection AddUserInjecions(
            this IServiceCollection services
            )
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

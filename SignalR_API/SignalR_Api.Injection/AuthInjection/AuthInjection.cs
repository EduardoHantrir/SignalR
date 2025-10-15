using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalR_Domains;
using SignalR_Domains.Interface;
using SignalR_Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Api.Injection.AuthInjection
{
    public static class AuthInjection
    {
        public static IServiceCollection AddAuthServices(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddHttpContextAccessor();
            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}

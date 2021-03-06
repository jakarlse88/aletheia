﻿using Aletheia.Infrastructure.OptionsObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aletheia.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures OIDC authentication with Auth0.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        internal static IServiceCollection ConfigureAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var authConfig = configuration.GetSection(Auth0Options.Auth0).Get<Auth0Options>();

                options.Authority = authConfig.Authority;
                options.Audience = authConfig.ApiIdentifier;
            });

            return services;
        }
    }
}

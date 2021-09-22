using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using UrnaEletronica.Application.AutoMapper;

namespace UrnaEletronica.Api.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}

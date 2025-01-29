using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Mappings;
using System;

namespace WebApplication.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
        }
    }
}

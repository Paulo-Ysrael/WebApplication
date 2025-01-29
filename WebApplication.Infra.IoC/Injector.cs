using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Services;
using WebApplication.Domain.Interfaces;
using WebApplication.Domain.InterfacesRepository;
using WebApplication.Domain.Service;
using WebApplication.Domain.Services;
using WebApplication.Infra.Data.Context;
using WebApplication.Infra.Data.Repository;

namespace WebApplication.Infra.IoC
{
    public static class Injector
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ServerConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            #region Service App
            services.AddScoped<IMermbersAppService, MermbersAppService>();
            services.AddScoped<ICompanyAppService, CompanyAppService>();
            services.AddScoped<IAssociationAppService, AssociationAppService>();
            #endregion

            #region Domain
            services.AddScoped<IMembersService, MembersService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAssociationService, AssociationService>();
            #endregion

            #region Repository
            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IAssociationRepository, AssociationRepository>();
            #endregion

            return services;
        }
    }
}

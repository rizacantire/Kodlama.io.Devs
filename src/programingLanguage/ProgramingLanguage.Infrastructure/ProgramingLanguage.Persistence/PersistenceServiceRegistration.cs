using Application.Services.Auths;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.Users;
using ProgramingLanguage.Persistence.Context;
using ProgramingLanguage.Persistence.Repositories;
using ProgramingLanguage.Persistence.Repositories.Users;
using ProgramingLanguageTechnology.Persistence.Repositories;

namespace ProgramingLanguage.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(
                options =>
                            options.UseSqlServer(configuration.GetConnectionString("SqlServeConnectionString"))
                            //options.UseSqlite(configuration.GetConnectionString("SqliteConnectionString"))
                    );
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILanguageTechnologyRepository, LanguageTechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IAuthService, AuthManager>();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Persistence.Context;
using ProgramingLanguage.Persistence.Repositories;

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
        }
    }
}

using Domain.Aggregates.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class StartupExtensions
    {
        public static IServiceCollection InitInfrastructure(this IServiceCollection services) => 
            services
            .AddDbContext<DatabaseContext>(opt =>
            {
                //opt.UseLazyLoadingProxies();
                opt.UseSqlite("Filename=TestDatabase.db");
            });

    }
}

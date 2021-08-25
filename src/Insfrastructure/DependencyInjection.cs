using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Common.Interfaces;
using Todo.Insfrastructure.Persistence;
using Todo.Insfrastructure.Services;

namespace Todo.Insfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("TodoDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(connectionString));
            }
            services.AddScoped<TodoDbContext>(provider => provider.GetService<TodoDbContext>());
            services.AddScoped<ITodoDbContext, TodoDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}

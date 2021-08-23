using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Insfrastructure.Persistence
{
    public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //           .SetBasePath(Directory.GetCurrentDirectory())
            //           .AddJsonFile("appsettings.Development.json")
            //           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            //var configurationSection = configuration.GetSection("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer("Server=(local);Database=todoList2;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TodoDbContext(optionsBuilder.Options);
        }
    }
}

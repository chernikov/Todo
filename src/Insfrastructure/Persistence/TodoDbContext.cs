using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Insfrastructure.Persistence
{
    public class TodoDbContext : DbContext, ITodoDbContext
    {
        public static readonly ILoggerFactory DbContextLoggerFactory
           = LoggerFactory.Create(builder =>
           {
               builder.AddConsole();
               builder.AddNLog();
           });

        private readonly IDateTime _dateTime;

        public TodoDbContext(
            DbContextOptions options,
            IDateTime dateTime) : base(options)
        {
         
            _dateTime = dateTime;
        }

        public TodoDbContext(
           DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(DbContextLoggerFactory);
            options.EnableSensitiveDataLogging(true);
            base.OnConfiguring(options);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}

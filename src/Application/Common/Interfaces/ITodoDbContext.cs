using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface ITodoDbContext
    {
        DbSet<TodoItem> Todos { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.TodoLists.Command.CreateTodo
{
    public class CreateTodoItemCommand : IRequest<int>
    {
          public string Name { get; set; }

    }


    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly ITodoDbContext _context; 

        public CreateTodoItemCommandHandler(ITodoDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem()
            {
                Name = request.Name,
                Status = Domain.Enums.StatusEnum.New
            };
            _context.Todos.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

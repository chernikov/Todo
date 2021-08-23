using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.TodoLists.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<List<TodoItemDto>>
    {
        
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoItemDto>>
    {
        private readonly ITodoDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(ITodoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TodoItemDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Todos.ToListAsync(cancellationToken);
            return _mapper.Map<List<TodoItemDto>>(list);
        }
    }
}

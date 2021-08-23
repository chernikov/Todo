using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Mappings;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.TodoLists.Queries.GetTodos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public StatusEnum Status { get; set; }
    }
}

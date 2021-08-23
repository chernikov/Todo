using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class TodoItem : EntityObject, IAuditableEntity
    {
        [MaxLength(150)]
        public string Name { get; set; }

       
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public DateTime? DueDate { get; set; }

        public StatusEnum Status { get; set; }
    }
}

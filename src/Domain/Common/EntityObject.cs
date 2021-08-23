using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Common
{
    public abstract class EntityObject : IEntityObject
    {
        public int Id { get; set; }
    }
}

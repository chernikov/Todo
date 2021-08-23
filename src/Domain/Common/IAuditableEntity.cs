using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Entities
{
    public class UserEvent
    {
        public int Id{ get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}

using SEMA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMA.Entities
{
   public class Events
    {
        public int Id{ get; set; }
        [StringLength(200, MinimumLength = 3)]
        public string Title{ get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        [ForeignKey("EventId")]
        public virtual ICollection<UserEvent> UserEvents { get; set; }

    }
}

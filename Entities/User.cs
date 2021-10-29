using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserEvent> UserEvents { get; set; }

    }
}

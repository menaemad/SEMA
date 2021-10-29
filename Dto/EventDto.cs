using SEMA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEMA.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }

    }
}

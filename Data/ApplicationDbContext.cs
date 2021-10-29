using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SEMA.Entities;
using System.Collections.Generic;

namespace SEMA.Data
{
    
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Events> Events { get; set; }
        public  DbSet<User> User { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
       

        
    }
}

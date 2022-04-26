using VikiNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VikiNet.Entity
{
    public class VikiNetDbContext : IdentityDbContext<ApplicationUser>
    {
        public VikiNetDbContext(DbContextOptions<VikiNetDbContext> options) : base(options)
        {

        }

        
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjectType> SubjectType { get; set; }
        
       
    }
}

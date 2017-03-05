using Microsoft.EntityFrameworkCore;
using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Repositories
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}

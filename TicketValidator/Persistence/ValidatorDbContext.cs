using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketValidator.Domain;

namespace TicketValidator.Persistence
{
    public class ValidatorDbContext : DbContext
    {
        public ValidatorDbContext(DbContextOptions<ValidatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValidatorDbContext).Assembly);
        }
    }
}

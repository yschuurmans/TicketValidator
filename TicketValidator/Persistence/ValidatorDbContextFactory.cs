using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketValidator.Persistence.Infrastructure;

namespace TicketValidator.Persistence
{
    public class ValidatorDbContextFactory : DesignTimeDbContextFactoryBase<ValidatorDbContext>
    {
        protected override ValidatorDbContext CreateNewInstance(DbContextOptions<ValidatorDbContext> options)
        {
            return new ValidatorDbContext(options);
        }
    }
}

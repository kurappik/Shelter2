using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shelter2.Models;

namespace Shelter2.Data
{
    public class Shelter2Context : DbContext
    {
        public Shelter2Context (DbContextOptions<Shelter2Context> options)
            : base(options)
        {
        }

        public DbSet<Shelter2.Models.Pets> Pets { get; set; } = default!;
    }
}

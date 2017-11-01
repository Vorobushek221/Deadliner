using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deadliner.Models
{
    public class DatabaseEntitiesCotext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseEntitiesCotext()
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=deadliner;Password=123123123;Server=localhost;Port=5432;Database=deadlinerdb;Integrated Security=true;Pooling=true;");
        }
    }
}

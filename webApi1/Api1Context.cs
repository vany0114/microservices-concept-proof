using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApi1
{
    public class Api1Context : DbContext
    {
        public Api1Context(DbContextOptions<Api1Context> options) : base(options)
        {
        }
        public DbSet<Entity1> Values { get; set; }
    }

    public class Entity1
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}

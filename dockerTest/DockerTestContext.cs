using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dockerTest
{
    public class DockerTestContext : DbContext
    {
        public DockerTestContext(DbContextOptions<DockerTestContext> options) : base(options)
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

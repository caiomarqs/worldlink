using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Models;

namespace WorldLink.Contexts
{
    public class WorldLinkDbContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public WorldLinkDbContext(DbContextOptions options) : base(options) { }
    }
}

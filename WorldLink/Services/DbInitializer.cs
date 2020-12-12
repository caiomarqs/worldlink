using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Contexts;
using WorldLink.Models;

namespace WorldLink.Services
{
    public class DbInitializer : IDbInitializer
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        //Metodo para a aplicação automatica das migrations
        public void Initialize()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<WorldLinkDbContext>();
        }

        public void SeedData()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<WorldLinkDbContext>();

            if (!context.Usuarios.Any())
            {
                var admin = new Usuario
                {
                    Nome = "admin",
                    Senha = "$2a$11$LcsE9q2asHR7y/CCqkjWSuI1CTMc.x8cPaQo/bSQCbjOber9RFKty" //admin
                };

                context.Usuarios.Add(admin);

                context.SaveChanges();
            }
        }
    }
}

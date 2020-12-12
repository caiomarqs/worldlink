using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldLink.Contexts;
using WorldLink.Repositories;

namespace WorldLink
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Para rodar no banco em memoria do EntityFramework, 
            //mude o parametro de GetConnectionString para "local",
            //Rode as migrations para criar o DB (exemplo no readme.md)
            //--- ou ----
            //Para o sqlsever troque para "sqlserver", 
            //lembre-se de trocar a string de conexao em appsettings.json
            //As tabelas podem ser criadas pelo o script .... , 
            //ou pode ser aplicadas as migrations
            services.AddDbContext<WorldLinkDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("local"))
            );

            services.AddScoped<IContatoRepository, ContatoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

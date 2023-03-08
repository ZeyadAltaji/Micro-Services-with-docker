using Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using platformWebAPIs.SyncDataServices.http;
using ProfileAutoMapper;
using Repo.classes;
using Repo.Interface;
using Repo.Preparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace platformWebAPIs
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
            services.AddDbContext<DBContext>(option => option.UseInMemoryDatabase("InMem"));

            services.AddScoped<IPlatfromsReop, PlatfromsReop>();
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
            services.AddControllers();
            services.AddAutoMapper(typeof(PlatfromProfrile).Assembly);
            Console.WriteLine($"--> commandservice Endpoint {Configuration["CommandService"]} ");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepDB.PrepPopulation(app);

        }
    }
}

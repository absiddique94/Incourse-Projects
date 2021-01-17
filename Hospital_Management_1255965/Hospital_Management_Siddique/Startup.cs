using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.DAL;
using Hospital_Management_Siddique.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_Management_Siddique
{
    public class Startup
    {
        public Startup(IConfiguration Config) { this.Config = Config; }
        public IConfiguration Config { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDbContext>(op => op.UseSqlServer(this.Config.GetConnectionString("projectdb")));
            services.AddScoped<IHospitalRepo, HospitalRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IDoctorRepo, DoctorRepo>();
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

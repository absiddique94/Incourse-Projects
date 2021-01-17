using System;
using Hospital_Management_Siddique.Areas.Identity.Data;
using Hospital_Management_Siddique.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Hospital_Management_Siddique.Areas.Identity.IdentityHostingStartup))]
namespace Hospital_Management_Siddique.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<AuthenticationUser>()
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}
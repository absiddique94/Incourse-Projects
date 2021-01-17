using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Project_Work_01.Startup))]

namespace Project_Work_01
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Login.aspx")
                });
        
        }
    }
}

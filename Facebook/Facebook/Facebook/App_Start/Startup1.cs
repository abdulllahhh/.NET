using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Facebook.App_Start.Startup1))]

namespace Facebook.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            CookieAuthenticationOptions cookieAuthuOptions = new CookieAuthenticationOptions();
            cookieAuthuOptions.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            cookieAuthuOptions.LoginPath = new PathString("/Account/Login");
            app.UseCookieAuthentication(cookieAuthuOptions);

        }
    }
}

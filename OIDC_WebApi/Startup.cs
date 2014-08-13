using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace OIDC_WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region OpenID Connect Authentication

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "464249156966-rb37ot28mrjgs0hgphnrvsg7vqs339l2.apps.googleusercontent.com",
                ClientSecret = "kIAonBCxrSzXAsTjMWkpbjqk",
                Authority = "https://accounts.google.com/",
                RedirectUri = "http://localhost:8080/api/login",
                ResponseType = "token id_token",
                //ResponseType =  "code",
                Scope = "openid",
            });

            #endregion

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

    }
}

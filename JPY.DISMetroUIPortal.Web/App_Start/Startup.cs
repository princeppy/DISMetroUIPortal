using System;
using System.Configuration;
using JPY.DISMetroUIPortal.Api.Controllers;
using JPY.DISMetroUIPortal.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Twitter;
using Owin;
using Microsoft.Owin.Extensions;

[assembly: OwinStartup(typeof(Startup))]

namespace JPY.DISMetroUIPortal.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            };

            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            app.UseCookieAuthentication(cookieOptions);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            if (IsTrue("ExternalAuth.Facebook.IsEnabled"))
            {
                app.UseFacebookAuthentication(CreateFacebookAuthOptions());
            }

            if (IsTrue("ExternalAuth.Twitter.IsEnabled"))
            {
                app.UseTwitterAuthentication(CreateTwitterAuthOptions());
            }

            if (IsTrue("ExternalAuth.Google.IsEnabled"))
            {
                app.UseGoogleAuthentication(CreateGoogleAuthOptions());
            }

            //Enable Mixed Authentication
            //As we are using LogonUserIdentity, its required to run in PipelineStage.PostAuthenticate
            //Register this after any middleware that uses stage marker PipelineStage.Authenticate
            app.UseStageMarker(PipelineStage.Authenticate);
            app.UseMixedAuth(new MohammadYounes.Owin.Security.MixedAuth.MixedAuthOptions()
            {
                Provider = new MohammadYounes.Owin.Security.MixedAuth.MixedAuthProvider()
                {
                    OnImportClaims = identity =>
                    {
                        System.Collections.Generic.List<System.Security.Claims.Claim> claims = new System.Collections.Generic.List<System.Security.Claims.Claim>();
                        using (var principalContext = new System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)) //or ContextType.Machine
                        {
                            using (System.DirectoryServices.AccountManagement.UserPrincipal userPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(principalContext, identity.Name))
                            {
                                if (userPrincipal != null)
                                {
                                    claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, userPrincipal.EmailAddress ?? string.Empty));
                                    claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Surname, userPrincipal.Surname ?? string.Empty));
                                    claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.GivenName, userPrincipal.GivenName ?? string.Empty));
                                }
                            }
                        }
                        return claims;
                    }
                }
            }, cookieOptions);
            app.UseStageMarker(PipelineStage.ResolveCache);
        }

        private static FacebookAuthenticationOptions CreateFacebookAuthOptions()
        {
            var options = new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["ExternalAuth.Facebook.AppId"],
                AppSecret = ConfigurationManager.AppSettings["ExternalAuth.Facebook.AppSecret"]
            };

            options.Scope.Add("email");
            options.Scope.Add("public_profile");

            return options;
        }

        private static TwitterAuthenticationOptions CreateTwitterAuthOptions()
        {
            return new TwitterAuthenticationOptions
            {
                ConsumerKey = ConfigurationManager.AppSettings["ExternalAuth.Twitter.ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["ExternalAuth.Twitter.ConsumerSecret"]
            };
        }

        private static GoogleOAuth2AuthenticationOptions CreateGoogleAuthOptions()
        {
            return new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["ExternalAuth.Google.ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["ExternalAuth.Google.ClientSecret"]
            };
        }

        private static bool IsTrue(string appSettingName)
        {
            return string.Equals(
                ConfigurationManager.AppSettings[appSettingName],
                "true",
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
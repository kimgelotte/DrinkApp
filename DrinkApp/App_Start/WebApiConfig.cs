using System.Web.Http;
namespace DrinkApp
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //configuration.SuppressDefaultHostAuthentication();
            //configuration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
            //    new { id = RouteParameter.Optional });
        }
    }
}
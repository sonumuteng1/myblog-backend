using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyBlogApp2.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Json tipinde dönüş sağlayan kod
            
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            

            // Web API routes
            config.MapHttpAttributeRoutes();
            
             //Sonsuz döngü hatasını engelleyen kod     
              config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
              Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            
            //Cors hatasını engellemek için yazılan kod. Önce kütüphane indirilmeli ondan sonra using System.Web.Http.Cors; import edilmeli sonra aşağıdaki kod yazılabilir. 
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );
            
        }
    }
}

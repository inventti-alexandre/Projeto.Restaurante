using System.Web;
using System.Web.Http;
using Projeto.Restaurante.WebApi.AutoMapper;

namespace Projeto.Restaurante.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.RegisterMappings();
        }
    }
}

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using Projeto.Restaurante.WebApi.AutoMapper;

namespace Projeto.Restaurante.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }
    }
}

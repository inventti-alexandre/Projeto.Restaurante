using Projeto.Restaurante.Aplicacao;
using Projeto.Restaurante.Aplicacao.Interfaces;
using Projeto.Restaurante.Dominio.Interfaces.Repositorios;
using Projeto.Restaurante.Dominio.Interfaces.Servicos;
using Projeto.Restaurante.Dominio.Servicos;
using Projeto.Restaurante.Infraestrutura.Dados.Repositorios;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Projeto.Restaurante.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Projeto.Restaurante.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Projeto.Restaurante.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAplicacaoBase<>)).To(typeof(AplicacaoBase<>));
            kernel.Bind<IAplicacaoCategoria>().To<AplicacaoCategoria>();
            kernel.Bind<IAplicacaoItem>().To<AplicacaoItem>();
            kernel.Bind<IAplicacaoMesa>().To<AplicacaoMesa>();
            kernel.Bind<IAplicacaoOpcao>().To<AplicacaoOpcao>();
            kernel.Bind<IAplicacaoPedido>().To<AplicacaoPedido>();
            kernel.Bind<IAplicacaoPrato>().To<AplicacaoPrato>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IServicoCategoria>().To<ServicoCategoria>();
            kernel.Bind<IServicoItem>().To<ServicoItem>();
            kernel.Bind<IServicoMesa>().To<ServicoMesa>();
            kernel.Bind<IServicoOpcao>().To<ServicoOpcao>();
            kernel.Bind<IServicoPedido>().To<ServicoPedido>();
            kernel.Bind<IServicoPrato>().To<ServicoPrato>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IRepositorioCategoria>().To<RepositorioCategoria>();
            kernel.Bind<IRepositorioItem>().To<RepositorioItem>();
            kernel.Bind<IRepositorioMesa>().To<RepositorioMesa>();
            kernel.Bind<IRepositorioOpcao>().To<RepositorioOpcao>();
            kernel.Bind<IRepositorioPedido>().To<RepositorioPedido>();
            kernel.Bind<IRepositorioPrato>().To<RepositorioPrato>();
        }        
    }
}

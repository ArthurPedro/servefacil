using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ServeFacil.Aplicacao.Apps;
using ServeFacil.Aplicacao.Interfaces;
using ServeFacil.App_Start;
using ServeFacil.Dominio.Interfaces;
using ServeFacil.Dominio.Interfaces.Repositorios;
using ServeFacil.Dominio.Interfaces.Servicos;
using ServeFacil.Dominio.Servicos;
using ServeFacil.Infra.Repositorios;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ServeFacil.App_Start
{
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
            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>));
            kernel.Bind<IAppUsuarioServico>().To<AppUsuarioServico>();
            kernel.Bind<IAppCategoriaServico>().To<AppCategoriaServico>();
            kernel.Bind<IAppImagenServico>().To<AppImagenServico>();
            kernel.Bind<IAppPlanoServico>().To<AppPlanoServico>();
            kernel.Bind<IAppPortifolioServico>().To<AppPortifolioServico>();
            kernel.Bind<IAppPortifolioPromovidoServico>().To<AppPortifolioPromovidoServico>();
            

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IImagenServico>().To<ImagensServico>();
            kernel.Bind<IPlanoServico>().To<PlanoServico>();
            kernel.Bind<ICategoriaServico>().To<CategoriaServico>();
            kernel.Bind<IPortifolioPromovidoServico>().To<PortifolioPromovidoServico>();
            kernel.Bind<IPortifolioServico>().To<PortifolioServico>();
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<ICategoriaRepositorio>().To<CategoriaRepositorio>();
            kernel.Bind<IPlanosRepositorio>().To<PlanosRepositorios>();
            kernel.Bind<IPortifolioRepositorio>().To<PortifolioRepositorio>();
            kernel.Bind<IPortPromovidosRepositorio>().To<PortPromovidosRepositorio>();
            kernel.Bind<IImagensRepositorio>().To<ImagensRepositorios>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
        }
    }
}

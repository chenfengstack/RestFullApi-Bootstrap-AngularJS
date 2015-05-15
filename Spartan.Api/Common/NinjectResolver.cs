using System.Web.Http;
using Ninject;
using Spartan.Model.DbContext;
using Spartan.Services.Interface;
using Spartan.Services.Services;

namespace Spartan.Api.Common
{
    public static class NinjectWebCommon
    {

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            //Suport WebAPI Injection
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.Ninject.NinjectResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            //设置注入对应关系
            kernel.Bind<SpartanDB>().To<SpartanDB>();
            kernel.Bind<INewService>().To<NewService>();
        }
    }
}
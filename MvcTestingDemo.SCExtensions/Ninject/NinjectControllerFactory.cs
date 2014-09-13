using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTestingDemo.SCExtensions.Ninject
{
    /// <summary>
    /// Original source: http://blog.istern.dk/2012/10/23/sitecore-mvc-new-ninject-controller-factory-clean-version/
    /// </summary>
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        public override void ReleaseController(IController controller)
        {
            _kernel.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_kernel.Get(controllerType);
        }
    }
}

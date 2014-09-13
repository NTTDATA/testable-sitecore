using Sitecore.Pipelines;
using System.Web.Mvc;
using SitecoreControllers = Sitecore.Mvc.Controllers;

namespace MvcTestingDemo.SCExtensions.Ninject
{
    /// <summary>
    /// Original source: http://blog.istern.dk/2012/10/23/sitecore-mvc-new-ninject-controller-factory-clean-version/
    /// </summary>
    public class InitializeNinjectControllerFactory
    {
        public virtual void Process(PipelineArgs args)
        {
            SetControllerFactory(args);
        }

        protected virtual void SetControllerFactory(PipelineArgs args)
        {
            var kernelFactory = new NinjectKernelFactory();
            var ninjectControllerFactory = new NinjectControllerFactory(kernelFactory.Create());
            var sitecoreControllerFactory = new SitecoreControllers.SitecoreControllerFactory(ninjectControllerFactory);
            ControllerBuilder.Current.SetControllerFactory(sitecoreControllerFactory);
        }
    }
}

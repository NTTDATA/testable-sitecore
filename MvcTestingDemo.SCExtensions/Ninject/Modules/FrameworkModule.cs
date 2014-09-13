using MvcTestingDemo.Business.Adapters;
using Ninject.Modules;

namespace MvcTestingDemo.SCExtensions.Ninject.Modules
{
    public class FrameworkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISitecoreContext>().To<SitecoreContext>();
        }
    }
}

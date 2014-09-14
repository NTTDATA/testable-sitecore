using MvcTestingDemo.Business;
using Ninject.Modules;

namespace MvcTestingDemo.App_Start
{
    public class MvcDemoModule : NinjectModule
    {
        public override void Load()
        {
            // Custom dependency mappings go here
            Bind<IMenuLogic>().To<MenuLogic>();
        }
    }
}
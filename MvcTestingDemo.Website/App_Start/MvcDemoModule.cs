using MvcTestingDemo.Business;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
using Ninject;
using Sitecore.Diagnostics;
using System;
using System.Linq;
using System.Reflection;

namespace MvcTestingDemo.SCExtensions.Ninject
{
    public class NinjectKernelFactory
    {
        /// <summary>
        /// Original source: http://blog.istern.dk/2012/10/23/sitecore-mvc-new-ninject-controller-factory-clean-version/
        /// </summary>
        public IKernel Create()
        {
            return LoadAssembliesIntoKernel(new StandardKernel());
        }

        private IKernel LoadAssembliesIntoKernel(IKernel kernel)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    kernel.Load(assembly);
                }
                catch (Exception)
                {
                    Log.Warn("Cannot load assembly:" + assembly.FullName, this);
                }
            }
            return kernel;
        }
    }
}
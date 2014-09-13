using Synthesis;

namespace MvcTestingDemo.Business.Adapters
{
    public interface ISiteContextAdapter
    {
        IStandardTemplateItem RootItem { get; }
        string Name { get;  }
    }
}

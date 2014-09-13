using Sitecore.Mvc.Presentation;
using Synthesis;
using Synthesis.FieldTypes.Adapters;

namespace MvcTestingDemo.Business.Adapters
{
    public interface ISitecoreContext
    {
        IStandardTemplateItem CurrentItem { get; }
        IStandardTemplateItem HomepageItem { get; }
        bool IsPageEditor { get; }
        bool IsPreview { get; }
        ISiteContextAdapter Site { get; }
        IDatabaseAdapter Database { get; }
        RenderingParameters Parameters { get; }
        IStandardTemplateItem DatasourceItem { get; }
        string Placeholder { get; }
    }
}

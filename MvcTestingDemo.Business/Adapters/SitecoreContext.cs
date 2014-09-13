using Sitecore.Mvc.Presentation;
using Synthesis;
using Synthesis.FieldTypes.Adapters;
using SC = Sitecore;

namespace MvcTestingDemo.Business.Adapters
{
    public class SitecoreContext : ISitecoreContext
    {
        private RenderingContext _rendering = RenderingContext.CurrentOrNull;

        public IStandardTemplateItem CurrentItem
        {
            get
            {
                return SC.Context.Item.AsStronglyTyped();
            }
        }

        public IDatabaseAdapter Database
        {
            get
            {
                return new DatabaseAdapter(SC.Context.Database);
            }
        }

        public IStandardTemplateItem DatasourceItem
        {
            get
            {
                if (_rendering != null && this._rendering.Rendering.Item != null)
                {
                    return _rendering.Rendering.Item.AsStronglyTyped();
                }
                return null;
            }
        }

        public IStandardTemplateItem HomepageItem
        {
            get
            {
                return this.Database.GetItem(SC.Context.Site.StartPath);
            }
        }

        public ISiteContextAdapter Site
        {
            get
            {
                return new SiteContextAdapter(SC.Context.Site, this.Database);
            }
        }

        public bool IsPageEditor
        {
            get
            {
                return SC.Context.PageMode.IsPageEditor;
            }
        }

        public bool IsPreview
        {
            get
            {
                return SC.Context.PageMode.IsPreview;
            }
        }

        public RenderingParameters Parameters
        {
            get
            {
                return _rendering.Rendering.Parameters;
            }
        }

        public string Placeholder
        {
            get
            {
                if (_rendering != null && _rendering.Rendering != null)
                {
                    return _rendering.Rendering.Placeholder;
                }
                return null;
            }
        }
    }
}

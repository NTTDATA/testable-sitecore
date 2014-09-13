using Sitecore.Sites;
using Synthesis;
using Synthesis.FieldTypes.Adapters;

namespace MvcTestingDemo.Business.Adapters
{
    public class SiteContextAdapter : ISiteContextAdapter
    {
        private readonly SiteContext _siteContext;
        private readonly IDatabaseAdapter _databaseAdapter;

        public SiteContextAdapter(SiteContext siteContext, IDatabaseAdapter databaseAdapter)
        {
            _siteContext = siteContext;
            _databaseAdapter = databaseAdapter;
        }

        public IStandardTemplateItem RootItem
        {
            get
            {
                return _databaseAdapter.GetItem(_siteContext.RootPath);
            }
        }

        public string Name
        {
            get { return _siteContext.Name; }
        }
    }
}

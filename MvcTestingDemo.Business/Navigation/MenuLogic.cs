using MvcTestingDemo.Business.Adapters;
using MvcTestingDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTestingDemo.Business
{
    public class MenuLogic : IMenuLogic
    {
        private readonly ISitecoreContext _context;

        public MenuLogic(ISitecoreContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItemModel> GetMenuItems()
        {
            // Using the context wrapper allows us to isolate ourselves from the Sitecore API
            // Not generally best practice to pull an item by path, but for the purposes of our demo...
            var menuContainer = _context.Database.GetItem("/sitecore/Content/Home");   
            var home = menuContainer as INavigableItem;

            if (home != null)
            {
                return GetMenuItem(home).Children;
            }

            return Enumerable.Empty<MenuItemModel>();
        }
        
        private MenuItemModel GetMenuItem(INavigableItem item)
        {
            var result = new MenuItemModel()
            {
                MenuItem = item,
            };

            result.Children = item.Axes.GetChildren()
                .OfType<INavigableItem>()
                .Where(i => i.IncludedInNavigation.Value)
                .Select(c => GetMenuItem(c));

            return result;
        }
        
    }
}

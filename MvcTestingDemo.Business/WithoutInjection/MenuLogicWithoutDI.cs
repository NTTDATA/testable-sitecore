using MvcTestingDemo.Models;
using Synthesis;
using System.Collections.Generic;
using System.Linq;

namespace MvcTestingDemo.Business.WithoutInjection
{
    public class MenuLogicWithoutDI : IMenuLogic
    {
        public IEnumerable<MenuItemModel> GetMenuItems()
        {
            // Directly using the static context - NOT testable!
            var menuContainer = Sitecore.Context.Database.GetItem("/sitecore/Content/Home");
            var home = menuContainer.As<INavigableItem>();

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

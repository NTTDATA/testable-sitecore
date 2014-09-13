using System.Collections.Generic;
using System.Linq;

namespace MvcTestingDemo.Models
{
    public class MenuItemModel
    {
        public INavigableItem MenuItem { get; set; }
        public IEnumerable<MenuItemModel> Children { get; set; }
        public bool HasChildren
        {
            get { return Children != null && Children.Any(); }
        }
    }
}
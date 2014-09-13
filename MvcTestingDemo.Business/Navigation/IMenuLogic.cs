using MvcTestingDemo.Models;
using System.Collections.Generic;

namespace MvcTestingDemo.Business
{
    public interface IMenuLogic
    {
        IEnumerable<MenuItemModel> GetMenuItems();
    }
}

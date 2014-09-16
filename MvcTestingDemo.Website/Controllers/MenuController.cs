using MvcTestingDemo.Business;
using System.Web.Mvc;

namespace MvcTestingDemo.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuLogic _menuLogic;

        // Using constructor injection to keep components isolated
        public MenuController(IMenuLogic menuLogic)
        {
            _menuLogic = menuLogic;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _menuLogic.GetMenuItems();
            return View("~/Views/Renderings/Navigation/Menu.cshtml", model);
        }
	}
}
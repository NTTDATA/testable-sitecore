using MvcTestingDemo.Business;
using MvcTestingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTestingDemo.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuLogic _menuLogic;

        public MenuController(IMenuLogic menuLogic)
        {
            _menuLogic = menuLogic;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _menuLogic.GetMenuItems();
            return View("~/Views/Sublayouts/Menu.cshtml", model);
        }
	}
}
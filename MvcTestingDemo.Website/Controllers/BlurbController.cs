using MvcTestingDemo.Business.Adapters;
using MvcTestingDemo.Models;
using System.Web.Mvc;

namespace MvcTestingDemo.Controllers
{
    public class BlurbController : Controller
    {
        private readonly ISitecoreContext _sitecoreContext;

        public BlurbController(ISitecoreContext sitecoreContext)
        {
            _sitecoreContext = sitecoreContext;
        }

        // Http Get
        public ActionResult Index()
        {
            var model = _sitecoreContext.DatasourceItem as IBlurbItem;
            return View("~/Views/Sublayouts/Blurb.cshtml", model);
        }
    }
}
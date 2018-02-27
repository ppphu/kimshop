using AutoMapper;
using KimShop.Model.Models;
using KimShop.Service;
using KimShop.Web.Models;
using System.Web.Mvc;

namespace KimShop.Web.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        // GET: Page
        public ActionResult Index(string alias)
        {
            var pageModel = _pageService.GetByAlias(alias);
            var pageViewModel = Mapper.Map<Page, PageViewModel>(pageModel);
            return View(pageViewModel);
        }
    }
}
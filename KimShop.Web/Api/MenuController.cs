using AutoMapper;
using KimShop.Model.Models;
using KimShop.Service;
using KimShop.Web.Infrastructure.Core;
using KimShop.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KimShop.Web.Api
{
    [RoutePrefix("api/menu")]
    public class MenuController : ApiControllerBase
    {
        private IMenuService _iMenuService;

        public MenuController(IErrorService errorService, IMenuService menuService)
            : base(errorService)
        {
            this._iMenuService = menuService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listMenu = _iMenuService.GetAll().ToList();

                var listMenuVm = Mapper.Map<List<Menu>, List<MenuViewModel>>(listMenu);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listMenuVm);

                return response;
            });
        }
    }
}
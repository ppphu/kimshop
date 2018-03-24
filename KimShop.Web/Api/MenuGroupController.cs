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
    [Authorize]
    [RoutePrefix("api/menugroup")]
    public class MenuGroupController : ApiControllerBase
    {
        private IMenuGroupService _iMenuGroupService;

        public MenuGroupController(IErrorService errorService, IMenuGroupService menuGroupService)
            : base(errorService)
        {
            this._iMenuGroupService = menuGroupService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listMenuGroup = _iMenuGroupService.GetAll().ToList();

                var listMenuGroupVm = Mapper.Map<List<MenuGroup>, List<MenuGroupViewModel>>(listMenuGroup);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listMenuGroupVm);

                return response;
            });
        }
    }
}
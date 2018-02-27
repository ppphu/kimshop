using KimShop.Service;
using KimShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace KimShop.Web.Api
{
    [Authorize]
    [RoutePrefix("api/home")]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorSevice) : base(errorSevice)
        {
            this._errorService = errorSevice;
        }

        [HttpGet]
        [Route("testmethod")]
        public string TestMethod()
        {
            return "Hello test method";
        }
    }
}
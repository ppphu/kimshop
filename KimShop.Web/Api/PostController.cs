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
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        IPostService _postService;
        public PostController(IErrorService errorService, IPostService posService)
            : base(errorService)
        {
            this._postService = posService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPost = _postService.GetAll().ToList();

                var listPostVm = Mapper.Map<List<Post>,List<PostViewModel>>(listPost);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostVm);

                return response;
            });
        }
    }
}
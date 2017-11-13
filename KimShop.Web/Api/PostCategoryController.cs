using KimShop.Model.Models;
using KimShop.Service;
using KimShop.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KimShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService posCategoryService)
            : base(errorService)
        {
            this._postCategoryService = posCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var listCategory = _postCategoryService.GetAll();

                    response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (ModelState.IsValid)
                 {
                     var category = _postCategoryService.Add(postCategory);
                     _postCategoryService.Save();

                     response = request.CreateResponse(HttpStatusCode.Created, category);
                 }
                 else
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 return response;
             });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
    }
}
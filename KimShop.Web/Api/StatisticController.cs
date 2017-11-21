﻿using KimShop.Service;
using KimShop.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KimShop.Web.Api
{
    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        private IStatisticService _statisticService;

        public StatisticController(IErrorService errorService, IStatisticService statisticService) : base(errorService)
        {
            _statisticService = statisticService;
        }

        //[Route("getrevenue")]
        //[HttpGet]
        //public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate, string toDate)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
        //        HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, null);
        //        return response;
        //    });
        //}
    }
}
using KimShop.Data.Repositories;
using System.Collections.Generic;

namespace KimShop.Service
{
    public interface IStatisticService
    {
        //IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class StatisticService : IStatisticService
    {
        //private IOrderRepository _orderRepository;

        //public StatisticService(IOrderRepository orderRepository)
        //{
        //    _orderRepository = orderRepository;
        //}

        //public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        //{
        //    return _orderRepository.GetRevenueStatistic(fromDate, toDate);
        //}
    }
}
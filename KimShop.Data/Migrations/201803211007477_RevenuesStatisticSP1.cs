namespace KimShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevenuesStatisticSP1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetRevenueStatistic",
                p => new
                {
                    fromDate = p.String(),
                    toDate = p.String()
                },
                @"select o.CreatedDate as Date,
                    sum(od.Quantity * p.OriginalPrice) as Benefit, sum(od.Quantity * od.Price) as Revenues
                    from Products p, Orders o, OrderDetails od
                    where  od.OrderID = o.ID and od.ProductID = p.ID
                    and o.CreatedDate <= cast(@toDate as date) and o.CreatedDate >= cast(@fromDate as date)
                    group by o.CreatedDate");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.GetRevenueStatistic");
        }
    }
}

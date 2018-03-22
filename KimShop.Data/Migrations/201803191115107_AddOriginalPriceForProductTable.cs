namespace KimShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOriginalPriceForProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppGroups", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.AppGroups", "Descripton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppGroups", "Descripton", c => c.String(maxLength: 250));
            DropColumn("dbo.Products", "OriginalPrice");
            DropColumn("dbo.AppGroups", "Description");
        }
    }
}

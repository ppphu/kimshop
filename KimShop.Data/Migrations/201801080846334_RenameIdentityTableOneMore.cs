namespace KimShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIdentityTableOneMore : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "AppRoles");
            RenameTable(name: "dbo.UserRoles", newName: "AppUserRoles");
            RenameTable(name: "dbo.Users", newName: "AppUsers");
            RenameTable(name: "dbo.UserClaims", newName: "AppUserClaims");
            RenameTable(name: "dbo.UserLogins", newName: "AppUserLogins");
            AddColumn("dbo.AppRoles", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.AppRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppRoles", "Discriminator");
            DropColumn("dbo.AppRoles", "Description");
            RenameTable(name: "dbo.AppUserLogins", newName: "UserLogins");
            RenameTable(name: "dbo.AppUserClaims", newName: "UserClaims");
            RenameTable(name: "dbo.AppUsers", newName: "Users");
            RenameTable(name: "dbo.AppUserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.AppRoles", newName: "Roles");
        }
    }
}

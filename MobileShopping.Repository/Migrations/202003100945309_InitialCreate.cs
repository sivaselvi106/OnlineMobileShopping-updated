namespace MobileShopping.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        MailId = c.String(),
                        Password = c.String(),
                        CreateDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        LastLoginTime = c.DateTime(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        MobileNo = c.Long(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false),
                        MobileModel = c.String(nullable: false),
                        Processor = c.String(nullable: false),
                        RAM = c.String(nullable: false),
                        Storage = c.String(nullable: false),
                        DisplaySize = c.String(nullable: false),
                        Slimness = c.String(nullable: false),
                        Pixel = c.String(nullable: false),
                        BatteryCapacity = c.String(nullable: false),
                        Color = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mobiles");
            DropTable("dbo.Accounts");
        }
    }
}

namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Subject = c.String(),
                        PrintingPlace = c.String(),
                        PrintCount = c.Int(nullable: false),
                        PrintDate = c.DateTime(nullable: false),
                        SupplyCategory = c.String(),
                        SupplyDate = c.DateTime(nullable: false),
                        PageCount = c.Int(nullable: false),
                        Image = c.String(),
                        Barcode = c.String(),
                        RelicStatus = c.Boolean(nullable: false),
                        WriterId = c.Int(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .Index(t => t.WriterId)
                .Index(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        PublishingHouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.WriterId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ReaderId);
            
            CreateTable(
                "dbo.Relics",
                c => new
                    {
                        RelicId = c.Int(nullable: false, identity: true),
                        BookBarcode = c.String(),
                        RelicDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelicId)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relics", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.Books", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Books", "PublishingHouseId", "dbo.PublishingHouses");
            DropIndex("dbo.Relics", new[] { "ReaderId" });
            DropIndex("dbo.Books", new[] { "PublishingHouseId" });
            DropIndex("dbo.Books", new[] { "WriterId" });
            DropTable("dbo.Users");
            DropTable("dbo.Relics");
            DropTable("dbo.Readers");
            DropTable("dbo.Writers");
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.Books");
        }
    }
}

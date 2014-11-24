namespace Seeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catogeries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.JopDates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        displayJopDate = c.DateTime(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        jopId = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jops", t => t.jopId, cascadeDelete: true)
                .ForeignKey("dbo.Catogeries", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.jopId)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Jops",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        mobile = c.String(),
                        address = c.String(),
                        cityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .Index(t => t.cityId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jops", new[] { "cityId" });
            DropIndex("dbo.JopDates", new[] { "categoryId" });
            DropIndex("dbo.JopDates", new[] { "jopId" });
            DropForeignKey("dbo.Jops", "cityId", "dbo.Cities");
            DropForeignKey("dbo.JopDates", "categoryId", "dbo.Catogeries");
            DropForeignKey("dbo.JopDates", "jopId", "dbo.Jops");
            DropTable("dbo.Jops");
            DropTable("dbo.JopDates");
            DropTable("dbo.Catogeries");
        }
    }
}

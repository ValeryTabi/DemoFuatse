namespace DemoFua.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatasets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country = c.String(),
                        city = c.String(),
                        latestCA = c.String(),
                        staffStrenth = c.Int(nullable: false),
                        ranking = c.String(),
                        risk = c.String(),
                        Doc = c.DateTime(nullable: false),
                        balaance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        otherNotes = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Funds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        requestDate = c.DateTime(nullable: false),
                        industry = c.String(),
                        status = c.String(),
                        isGranted = c.Boolean(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        projectName = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Funds", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Projects", new[] { "CompanyId" });
            DropIndex("dbo.Funds", new[] { "CompanyId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Funds");
            DropTable("dbo.Companies");
        }
    }
}

namespace Asela.Samples.Wpf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Remarks = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}

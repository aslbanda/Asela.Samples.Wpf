namespace Asela.Samples.Wpf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeDeptIdadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Employees", name: "Department_Id", newName: "DeptId");
            AlterColumn("dbo.Employees", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DeptId");
            AddForeignKey("dbo.Employees", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DeptId" });
            AlterColumn("dbo.Employees", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "DeptId", newName: "Department_Id");
            CreateIndex("dbo.Employees", "Department_Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
        }
    }
}

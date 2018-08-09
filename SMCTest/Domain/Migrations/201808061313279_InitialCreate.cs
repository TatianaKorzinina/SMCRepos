namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentTitle = c.String(nullable: false),
                        Organization_OrganizationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationID, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationID);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        OrganizationTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Organization_OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Employes", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employes", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Departments", new[] { "Organization_OrganizationID" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Employes");
            DropTable("dbo.Departments");
        }
    }
}

namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogTypeClass1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        dateTime = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Organization = c.String(),
                        Department = c.String(),
                        Employee_EmployeeId = c.Int(),
                        LogType_LogTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Employes", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.LogTypes", t => t.LogType_LogTypeId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.LogType_LogTypeId);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        LogTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.LogTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "LogType_LogTypeId", "dbo.LogTypes");
            DropForeignKey("dbo.Logs", "Employee_EmployeeId", "dbo.Employes");
            DropIndex("dbo.Logs", new[] { "LogType_LogTypeId" });
            DropIndex("dbo.Logs", new[] { "Employee_EmployeeId" });
            DropTable("dbo.LogTypes");
            DropTable("dbo.Logs");
        }
    }
}

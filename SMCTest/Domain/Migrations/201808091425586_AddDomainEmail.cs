namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDomainEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employes", "Email");
        }
    }
}

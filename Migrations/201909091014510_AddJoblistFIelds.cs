namespace Ef_codefirst_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJoblistFIelds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobLists", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.JobLists", "JobRole", c => c.String(nullable: false));
            AlterColumn("dbo.JobLists", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.JobLists", "Skill", c => c.String(nullable: false));
            AlterColumn("dbo.JobLists", "Timestamp", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobLists", "Timestamp", c => c.String());
            AlterColumn("dbo.JobLists", "Skill", c => c.String());
            AlterColumn("dbo.JobLists", "Description", c => c.String());
            AlterColumn("dbo.JobLists", "JobRole", c => c.String());
            AlterColumn("dbo.JobLists", "CompanyName", c => c.String());
        }
    }
}

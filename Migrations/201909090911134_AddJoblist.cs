namespace Ef_codefirst_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJoblist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        JobRole = c.String(),
                        Description = c.String(),
                        Skill = c.String(),
                        Timestamp = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.jobLists");
        }
    }
}

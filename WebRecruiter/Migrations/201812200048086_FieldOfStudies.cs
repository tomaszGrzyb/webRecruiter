namespace WebRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldOfStudies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "UserId");
        }
    }
}

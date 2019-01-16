namespace WebRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamResults", "CandidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamResults", "CandidateId");
            AddForeignKey("dbo.ExamResults", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.ExamResults", new[] { "CandidateId" });
            DropColumn("dbo.ExamResults", "CandidateId");
        }
    }
}

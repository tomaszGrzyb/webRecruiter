namespace WebRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBasicModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "CorrespondenceAddressId", "dbo.Addresses");
            DropIndex("dbo.Candidates", new[] { "CorrespondenceAddressId" });
            DropColumn("dbo.Candidates", "CorrespondenceAddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "CorrespondenceAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidates", "CorrespondenceAddressId");
            AddForeignKey("dbo.Candidates", "CorrespondenceAddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}

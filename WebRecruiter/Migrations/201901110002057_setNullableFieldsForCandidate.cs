namespace WebRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setNullableFieldsForCandidate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Candidates", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Candidates", new[] { "AddressId" });
            DropIndex("dbo.Candidates", new[] { "DocumentId" });
            AlterColumn("dbo.Candidates", "AddressId", c => c.Int());
            AlterColumn("dbo.Candidates", "DocumentId", c => c.Int());
            CreateIndex("dbo.Candidates", "AddressId");
            CreateIndex("dbo.Candidates", "DocumentId");
            AddForeignKey("dbo.Candidates", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Candidates", "DocumentId", "dbo.Documents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Candidates", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Candidates", new[] { "DocumentId" });
            DropIndex("dbo.Candidates", new[] { "AddressId" });
            AlterColumn("dbo.Candidates", "DocumentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidates", "DocumentId");
            CreateIndex("dbo.Candidates", "AddressId");
            AddForeignKey("dbo.Candidates", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}

namespace WebRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filledDbSets : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "User");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetRoles", newName: "Role");
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        ReceivedPoints = c.Short(nullable: false),
                        IsAdvanced = c.Boolean(nullable: false),
                        ExamSubjectId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubjects", t => t.ExamSubjectId, cascadeDelete: true)
                .Index(t => t.ExamSubjectId);
            
            CreateTable(
                "dbo.ExamSubjects",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FieldOfStudyRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequiredPoints = c.Short(nullable: false),
                        FieldOfStudyId = c.Short(nullable: false),
                        ExamSubjectId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubjects", t => t.ExamSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.FieldOfStudies", t => t.FieldOfStudyId, cascadeDelete: true)
                .Index(t => t.FieldOfStudyId)
                .Index(t => t.ExamSubjectId);
            
            CreateTable(
                "dbo.FieldOfStudies",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LimitOfStudents = c.Short(nullable: false),
                        StudyTypeId = c.Short(nullable: false),
                        StudyDegreeId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyDegrees", t => t.StudyDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.StudyTypes", t => t.StudyTypeId, cascadeDelete: true)
                .Index(t => t.StudyTypeId)
                .Index(t => t.StudyDegreeId);
            
            CreateTable(
                "dbo.StudyDegrees",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyTypes",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recruitments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        FieldOfStudyId = c.Short(nullable: false),
                        RecruitmentStatusId = c.Short(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.FieldOfStudies", t => t.FieldOfStudyId, cascadeDelete: true)
                .ForeignKey("dbo.RecruitmentStatus", t => t.RecruitmentStatusId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.FieldOfStudyId)
                .Index(t => t.RecruitmentStatusId);
            
            CreateTable(
                "dbo.RecruitmentStatus",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruitments", "RecruitmentStatusId", "dbo.RecruitmentStatus");
            DropForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.Recruitments", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.FieldOfStudies", "StudyTypeId", "dbo.StudyTypes");
            DropForeignKey("dbo.FieldOfStudies", "StudyDegreeId", "dbo.StudyDegrees");
            DropForeignKey("dbo.FieldOfStudyRequirements", "FieldOfStudyId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.FieldOfStudyRequirements", "ExamSubjectId", "dbo.ExamSubjects");
            DropForeignKey("dbo.ExamResults", "ExamSubjectId", "dbo.ExamSubjects");
            DropIndex("dbo.Recruitments", new[] { "RecruitmentStatusId" });
            DropIndex("dbo.Recruitments", new[] { "FieldOfStudyId" });
            DropIndex("dbo.Recruitments", new[] { "CandidateId" });
            DropIndex("dbo.FieldOfStudies", new[] { "StudyDegreeId" });
            DropIndex("dbo.FieldOfStudies", new[] { "StudyTypeId" });
            DropIndex("dbo.FieldOfStudyRequirements", new[] { "ExamSubjectId" });
            DropIndex("dbo.FieldOfStudyRequirements", new[] { "FieldOfStudyId" });
            DropIndex("dbo.ExamResults", new[] { "ExamSubjectId" });
            DropTable("dbo.RecruitmentStatus");
            DropTable("dbo.Recruitments");
            DropTable("dbo.StudyTypes");
            DropTable("dbo.StudyDegrees");
            DropTable("dbo.FieldOfStudies");
            DropTable("dbo.FieldOfStudyRequirements");
            DropTable("dbo.ExamSubjects");
            DropTable("dbo.ExamResults");
            RenameTable(name: "dbo.Role", newName: "AspNetRoles");
            RenameTable(name: "dbo.UserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.User", newName: "AspNetUsers");
        }
    }
}

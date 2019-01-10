using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<RecruitmentStatus> RecruitmentStatuses { get; set; }
        public DbSet<FieldOfStudy> FieldsOfStudies { get; set; }
        public DbSet<ExamSubject> ExamSubjects { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<FieldOfStudyRequirement> FieldOfStudyRequirements { get; set; }
        public DbSet<StudyDegree> StudyDegreeses { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }
		
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
			Database.SetInitializer(new ApplicationDbInitializer());
		}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRecruiter.Models
{
	public class ApplicationDbInitializer<T> : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			IList<DocumentType> defaultDocumentTypes = new List<DocumentType>();
			defaultDocumentTypes.Add(new DocumentType() { Name = "Dowód osobisty" });
			defaultDocumentTypes.Add(new DocumentType() { Name = "Paszport" });
			context.DocumentTypes.AddRange(defaultDocumentTypes);

			////public virtual ICollection<FieldOfStudyRequirement> Requirements { get; set; }

			//IList<StudyType> defaultStudyTypes = new List<StudyType>();
			//defaultStudyTypes.Add(new StudyType() { Name = "Stacjonarne" });
			//defaultStudyTypes.Add(new StudyType() { Name = "Niestacjonarne" });
			//context.StudyTypes.AddRange(defaultStudyTypes);

			//IList<StudyDegree> defaultStudyDegrees = new List<StudyDegree>();
			//defaultStudyDegrees.Add(new StudyDegree() { Name = "Inżynierskie" });
			//defaultStudyDegrees.Add(new StudyDegree() { Name = "Licencjackie" });
			//defaultStudyDegrees.Add(new StudyDegree() { Name = "Magisterskie" });
			//context.StudyDegreeses.AddRange(defaultStudyDegrees);

			//IList<ExamSubject> defaultExamSubjects = new List<ExamSubject>();
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Informatyka" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Matematyka" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Fizyka" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Biologia" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Chemia" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Geografia" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Język polski" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Język angielski" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Chemia" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "Historia" });
			//defaultExamSubjects.Add(new ExamSubject() { Name = "WOS" });
			//context.ExamSubjects.AddRange(defaultExamSubjects);


			//IList<FieldOfStudy> defaultFieldOfStudies = new List<FieldOfStudy>();
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Informatyka" });
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Finanse i rachunkowść" });
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Leśnictwo" });
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Budownictwo" });
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Rolnictwo" });
			//defaultFieldOfStudies.Add(new FieldOfStudy() { Name = "Inżynieria produkcji" });
			//context.FieldsOfStudies.AddRange(defaultFieldOfStudies);

			//IList<FieldOfStudyRequirement> defaultStudyRequirements = new List<FieldOfStudyRequirement>();
			//defaultStudyRequirements.Add(new FieldOfStudyRequirement()
			//{
			//	ExamSubjectId = defaultExamSubjects[0].Id,
			//	RequiredPoints = 70,
			//	FieldOfStudyId = defaultFieldOfStudies[0].Id
			//});
			//defaultStudyRequirements.Add(new FieldOfStudyRequirement()
			//{
			//	ExamSubjectId = defaultExamSubjects[0].Id,
			//	RequiredPoints = 75,
			//	FieldOfStudyId = defaultFieldOfStudies[1].Id
			//});
			//defaultStudyRequirements.Add(new FieldOfStudyRequirement()
			//{
			//	ExamSubjectId = defaultExamSubjects[1].Id,
			//	RequiredPoints = 60,
			//	FieldOfStudyId = defaultFieldOfStudies[2].Id
			//});

			//context.FieldOfStudyRequirements.AddRange(defaultStudyRequirements);

			//IList<RecruitmentStatus> defaultRecruitmentStatuses = new List<RecruitmentStatus>();
			//defaultRecruitmentStatuses.Add(new RecruitmentStatus() { Name = "Utworzona" });
			//defaultRecruitmentStatuses.Add(new RecruitmentStatus() { Name = "Czeka na zapłatę" });
			//defaultRecruitmentStatuses.Add(new RecruitmentStatus() { Name = "Opłacona" });
			//defaultRecruitmentStatuses.Add(new RecruitmentStatus() { Name = "Zakończona" });
			//defaultRecruitmentStatuses.Add(new RecruitmentStatus() { Name = "Anulowana" });
			//context.RecruitmentStatuses.AddRange(defaultRecruitmentStatuses);

			base.Seed(context);
		}

		private void InitializeRoles(ApplicationDbContext context)
		{
			var roles = new List<IRole>();
			var store = new RoleStore<IdentityRole>(context);
			var manager = new RoleManager<IdentityRole>(store);

			var roleAdmin = new IdentityRole { Name = "Admin" };
			var roleUser = new IdentityRole { Name = "User" };

			manager.Create(roleAdmin);
			manager.Create(roleUser);
		}


	}
}
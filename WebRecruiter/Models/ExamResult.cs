using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebRecruiter.Models
{
    public class ExamResult
    {
        public short Id { get; set; }

		[Required]
		[DisplayName("Otrzymane punkty")]
		public short ReceivedPoints { get; set; }

		[Required]
		[DisplayName("Czy matura rozszerzona?")]
		public bool IsAdvanced { get; set; }

		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }

		public short ExamSubjectId { get; set; }
        public ExamSubject ExamSubject { get; set; }
    }
}
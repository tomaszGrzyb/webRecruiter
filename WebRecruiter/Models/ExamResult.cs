namespace WebRecruiter.Models
{
    public class ExamResult
    {
        public short Id { get; set; }
        public short ReceivedPoints { get; set; }
        public bool IsAdvanced { get; set; }
        public short ExamSubjectId { get; set; }
        public ExamSubject ExamSubject { get; set; }
    }
}
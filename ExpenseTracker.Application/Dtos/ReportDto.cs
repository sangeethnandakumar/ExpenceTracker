namespace Application.Dtos
{
    public class ReportDto
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Total { get; set; }
        public Dictionary<Guid, ReportCategoryBreakdown> Breakdown { get; set; }
    }

    public class ReportCategoryBreakdown
    {
        public string Title { get; set; }
        public int Total { get; set; }
        public List<ReportTrack> Tracks { get; set; }
    }

    public class ReportTrack
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Exp { get; set; }
        public int Inc { get; set; }
        public string Notes { get; set; }
    }
}

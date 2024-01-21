namespace HearingsApi
{
    public class Hearing
    {
        private string? _processNumber;
        private DateTime? _date { get; set; }
        private string? _court { get; set; }
        private string? _correspondent { get; set; }
        public Hearing() { }
        public string? ProcessNumber { get; set; }
        public string? Date { get; set; }
        public string? Court { get; set; }
        public string? Correspondent { get; set; }


    }
}

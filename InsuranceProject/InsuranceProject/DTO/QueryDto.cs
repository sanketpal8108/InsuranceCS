namespace InsuranceProject.DTO
{
    public class QueryDto
    {
        public int Id { get; set; }
        public string QueryTitle { get; set; }
        public string QueryMessage { get; set; }
        public DateTime QueryDate { get; set; }
        public string Reply { get; set; }
        public int CustomerId { get; set; }

    }
}

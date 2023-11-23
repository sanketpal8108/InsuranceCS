namespace InsuranceProject.DTO
{
    public class CommisionDto
    {
        public int Id { get; set; }
        public int InsurancePlanId { get; set; }
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public double CommisionAmount { get; set; }
    }
}

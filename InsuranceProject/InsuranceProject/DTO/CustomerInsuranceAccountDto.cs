namespace InsuranceProject.DTO
{
    public class CustomerInsuranceAccountDto
    {
        public int Id { get; set; }
        public DateTime InsuranceCreationDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public int PolicyTerm { get; set; }
        public double TotalPremium { get; set; }
        public double ProfitRatio { get; set; }
        public double SumAssured { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }
    }
}

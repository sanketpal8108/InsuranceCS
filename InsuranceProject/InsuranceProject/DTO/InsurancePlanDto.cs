namespace InsuranceProject.DTO
{
    public class InsurancePlanDto
    {
        public int Id { get; set; }
        public int MinPolicyTerm { get; set; }
        public int MaxPolicyTerm { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public double MinInvestmentAmount { get; set; }
        public double MaxInvestmentAmount { get; set; }
        public double ProfitRatioPercentage { get; set; }
        public int InsuranceSchemeId { get; set; }

    }
}

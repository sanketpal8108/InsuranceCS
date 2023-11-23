namespace InsuranceProject.DTO
{
    public class PolicyClaimDto
    {
        public int Id { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public string BankName { get; set; }
        public double WithdrawalAmount { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }

    }
}

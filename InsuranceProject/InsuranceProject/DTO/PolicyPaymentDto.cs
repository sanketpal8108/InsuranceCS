namespace InsuranceProject.DTO
{
    public class PolicyPaymentDto
    {
        public int Id { get; set; }
        public double PaidAmount { get; set; }
        public double TaxAmount { get; set; }
        public double TotalAmount { get; set; }
        public DateTime PaidDate { get; set; }
        public string TransactionType { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }


    }
}

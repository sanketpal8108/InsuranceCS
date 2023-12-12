namespace InsuranceProject.DTO
{
    public class PolicyPaymentDto
    {
        public int Id { get; set; }
        public double PaidAmount { get; set; }
        public double TaxAmount { get; set; }
        public double TotalAmount { get; set; }
        public DateOnly PaidDate { get; set; }
        public string TransactionType { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }
        public bool? IsPaid { get; set; }
        public int CustomerInsuranceAccountId { get; set; }


    }
}

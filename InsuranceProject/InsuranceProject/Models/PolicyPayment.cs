using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class PolicyPayment
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public InsurancePlan? InsurancePlan { get; set; }
        [ForeignKey("InsurancePlan")]
        public int InsurancePlanId { get;set; }
        public CustomerInsuranceAccount CustomerInsuranceAccount { get; set; }
        [ForeignKey("CustomerInsuranceAccount")]
        public int CustomerInsuranceAccountId { get; set; }
        public double PaidAmount { get; set; }
        public double TaxAmount { get; set; }   
        public double TotalAmount {get; set; }
        public DateTime PaidDate { get; set; }
        public string TransactionType { get; set; }
        public bool? IsPaid { get; set; }

        public bool IsActive { get; set; }

    }
}

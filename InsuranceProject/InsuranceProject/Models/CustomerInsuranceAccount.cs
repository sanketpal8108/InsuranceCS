using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class CustomerInsuranceAccount
    {
        public int Id { get; set; } 
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public InsurancePlan? InsurancePlan { get; set; }
        [ForeignKey("InsurancePlan")]
        public int InsurancePlanId { get; set; }
        public PolicyClaim? PolicyClaim { get; set; }
        public List<PolicyPayment>? PolicyPayment { get; set; }
        public DateTime InsuranceCreationDate { get; set; } = DateTime.Now;
        public DateTime MaturityDate { get; set; }
        public int PolicyTerm { get; set; }
        public double TotalPremium { get; set; }
        public double ProfitRatio { get; set; }
        public double SumAssured { get; set; }
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class PolicyClaim
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
        public bool? IsApproved { get; set; }
        public DateTime ClaimDate { get; set; } = DateTime.Now;
        public string BankName { get; set; }
        public double ClaimAmount { get; set; }
        public double WithdrawalAmount { get; set; }
        public DateTime WithdrawalDate { get; set; }

        public bool IsActive { get; set; }

    }
}

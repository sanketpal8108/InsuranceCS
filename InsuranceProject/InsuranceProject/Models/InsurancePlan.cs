using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class InsurancePlan
    {
        public int Id { get; set; } 
        public InsuranceScheme? insuranceScheme { get; set; }
        [ForeignKey("InsuranceScheme")]
        public int InsuranceSchemeId { get; set; }
        public int MinPolicyTerm { get; set; }
        public int MaxPolicyTerm { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public double MinInvestmentAmount { get; set; }
        public double MaxInvestmentAmount { get;set; }
        public double ProfitRatioPercentage { get; set; }
        public bool IsActive { get; set; }
        public List<Commision>? Commisions { get; set; }
        public List<CustomerInsuranceAccount>? CustomerInsuranceAccounts { get; set; }
        public List<PolicyPayment>? PolicyPayments { get; set; }
        public List<PolicyClaim>? PolicyClaims { get; set; }


    }
}

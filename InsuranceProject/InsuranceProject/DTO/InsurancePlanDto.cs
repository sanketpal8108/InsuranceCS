using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class InsurancePlanDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "MinPolicyTerm is Required.")]
        public int MinPolicyTerm { get; set; }
        [Required(ErrorMessage = "MaxPolicyTerm is Required.")]
        //[StringLength(60, ErrorMessage = "MaxPolicyTerm must be no more than 60 characters.")]
        public int MaxPolicyTerm { get; set; }
        [Required(ErrorMessage = "MinAge is Required.")]

        public int MinAge { get; set; }
        [Required(ErrorMessage = "MaxAge is Required.")]
        public int MaxAge { get; set; }
        [Required(ErrorMessage = "MinInvestmentAmount is Required.")]
        public double MinInvestmentAmount { get; set; }
        [Required(ErrorMessage = "MaxInvestmentAmount is Required.")]
        public double MaxInvestmentAmount { get; set; }
        [Required(ErrorMessage = "ProfitRatioPercentage  is Required.")]
        public double ProfitRatioPercentage { get; set; }
        public int InsuranceSchemeId { get; set; }

    }
}

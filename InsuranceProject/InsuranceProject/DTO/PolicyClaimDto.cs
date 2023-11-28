using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class PolicyClaimDto
    {
        public int Id { get; set; }
        public DateOnly WithdrawalDate { get; set; }
        [Required(ErrorMessage = " BankName is Required.")]
        public string BankName { get; set; }
        public double WithdrawalAmount { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }

    }
}

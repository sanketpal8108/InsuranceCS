using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class CommisionWithdrawalDto
    {
        public int Id { get; set; }
        public DateOnly RequestDate { get; set; }
        [Required(ErrorMessage = "WithdrawalAmount is Required.")]
        public double WithdrawalAmount { get; set; }
        //public double TotalWithdrawalAmount { get; set; }
        public int AgentId { get; set; }
        public bool IsApproved { get; set; }
    }
}

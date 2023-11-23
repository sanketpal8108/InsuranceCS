namespace InsuranceProject.DTO
{
    public class CommisionWithdrawalDto
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
       
        public double WithdrawalAmount { get; set; }
        public double TotalWithdrawalAmount { get; set; }
        public bool IsApproved { get; set; }
    }
}

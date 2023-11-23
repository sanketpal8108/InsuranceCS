using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Commision
    {
        public int Id { get; set; }
        public InsurancePlan? InsurancePlan { get; set; }
        [ForeignKey("InsurancePlan")]
        public int InsurancePlanId { get; set; } //InsuranceNumber
        public Agent? Agent { get; set; }
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        //public DateTime CommisionDate { get; } = DateTime.Now;
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public double CommisionAmount { get; set; }

        public bool IsActive { get; set; }
    }
}

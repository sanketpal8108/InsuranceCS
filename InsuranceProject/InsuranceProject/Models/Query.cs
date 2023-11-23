using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Query
    {
        public int Id { get; set; }
        public string QueryTitle { get; set; }
        public string QueryMessage { get; set; }
        public DateTime QueryDate { get; set; } = DateTime.Now;
        public string Reply { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public bool IsActive { get; set; }

    }
}
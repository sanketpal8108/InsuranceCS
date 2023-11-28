using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class QueryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "QueryTitle is Required.")]
        public string QueryTitle { get; set; }
        [Required(ErrorMessage = "QueryMessage is Required.")]
        public string QueryMessage { get; set; }
        public DateOnly QueryDate { get; set; }
        public string Reply { get; set; }
        public int CustomerId { get; set; }

    }
}

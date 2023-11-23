namespace InsuranceDay1.Models
{
    public class InsuranceType
    {
        public int Id { get; set; }
        public string InsuranceTypeName { get; set; }
        public bool IsActive { get; set; }
        public List<InsuranceScheme>? InsuranceSchemes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class InsuranceScheme
    {
        public int Id { get; set; }
        public InsuranceType? InsuranceType { get; set; }
        [ForeignKey("InsuranceType")]
        public int InsuranceTypeId { get; set; }
        public string InsuranceSchemeName { get; set; }
        // public Image Attribute
        public byte[]? InsuranceSchemeImage { get; set; }
        public double NewRegistrastionCommision { get; set; }
        public double InstallmentPaymentCommision { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public List<InsurancePlan>? InsurancePlans { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class InsuranceSchemeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "InsuranceSchemeName is Required.")]
        [StringLength(50, ErrorMessage = "InsuranceSchemeName must be no more than 50 characters.")]
        public string InsuranceSchemeName { get; set; }

        public double NewRegistrastionCommision { get; set; }
        public double InstallmentPaymentCommision { get; set; }
        //public byte[] InsuranceSchemeImage { get; set; }
        [Required(ErrorMessage = "Details  is Required.")]
        public string Details { get; set; }
        [Required(ErrorMessage = "InsuranceTypeId is Required.")]
        public int InsuranceTypeId { get; set; }

    }
}

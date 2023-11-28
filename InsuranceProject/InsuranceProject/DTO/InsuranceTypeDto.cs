using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class InsuranceTypeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "InsuranceTypeName  is Required.")]
        [StringLength(50, ErrorMessage = "InsuranceTypeName  must be no more than 50 characters.")]
        public string InsuranceTypeName { get; set; }
    }
}

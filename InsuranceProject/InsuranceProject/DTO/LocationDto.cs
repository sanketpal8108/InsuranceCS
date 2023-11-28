using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "State is Required.")]
        [StringLength(15, ErrorMessage = "State must be no more than 15 characters.")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is Required.")]
        [StringLength(10, ErrorMessage = "City must be no more than 10 characters.")]

        public string City { get; set; }

        public int CountCustomer { get; set; }
    }
}

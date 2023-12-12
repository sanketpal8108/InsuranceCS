using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "UserName is Required.")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "FirstName is Required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "MobileNumber is Required.")]
        public int MobileNumber { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "NomineeName is Required.")]
        public string NomineeName { get; set; }
        [Required(ErrorMessage = "NomineeRelation is Required.")]
        public string NomineeRelation { get; set; }
        [Required(ErrorMessage = "LocationId is Required.")]
        public int LocationId { get; set; }
        public int? AgentId { get; set; }//public int RoleId { get; set; }
    }
}

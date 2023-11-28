using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class AgentDto
    {
        //[Key]
        //[Required(ErrorMessage = "Id Name is Required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        [StringLength(50, ErrorMessage = "First Name must be no more than 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Name is Required.")]
        [StringLength(50, ErrorMessage = "LastName must be no more than 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is Required.")]
        [StringLength(50, ErrorMessage = "UserName must be no more than 50 characters.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [StringLength(15, ErrorMessage = "Password must be no more than 15 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "MobileNumber is Required.")]
        //[StringLength(10, ErrorMessage = "MobileNumber must be no more than 10 characters.")]
        public int MobileNumber { get; set; }
        [Required(ErrorMessage = " Email is Required.")]
        public string Email { get; set; }
        public double Commision { get; set; } = 0;
        public double TotalCommision { get; set; }

        public int CountCustomer { get; set; } = 0;

        public int CountCommision { get; set; } = 0;


    }
}

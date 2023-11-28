using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class AdminDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is Required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }

        //public int RoleId { get; set; }
        public int CountAdmin { get; set; }
    }
}

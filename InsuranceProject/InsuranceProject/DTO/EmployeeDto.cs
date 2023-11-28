using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is Required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName is Required.")]

        public string UserName { get; set; } //LoginID
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
        //public int RoleId { get; set; }


    }
}

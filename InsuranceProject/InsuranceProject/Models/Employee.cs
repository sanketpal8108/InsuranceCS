using InsuranceProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } //LoginID
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}

using InsuranceProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public double Commision { get; set; } = 0;
        //public List<Customer> Customers {get; set;}
        public bool IsActive { get; set; } 
        public List<Commision>? Commisions { get; set; }
        public double TotalCommision { get; set; } 

        public List<Customer>? Customers { get; set; }

        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}

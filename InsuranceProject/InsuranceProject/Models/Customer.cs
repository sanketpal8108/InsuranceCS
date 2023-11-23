using InsuranceProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Location? Location { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public bool IsActive { get; set; }
        public List<Documents>? Documents { get; set; }
        //[ForeignKey("Documents")]
        //public int DocumentId { get; set; }
        public List<Query>? Queries { get; set; }
        public List<CustomerInsuranceAccount>? CustomerInsuranceAccounts { get; set;}
        public List<PolicyPayment>? PolicyPayments { get; set; }
        public List<PolicyClaim>? PolicyClaims { get; set; }

        public Agent? Agent { get; set; }
        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

    }
}

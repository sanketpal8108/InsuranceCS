using InsuranceDay1.Models;

namespace InsuranceProject.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public List<Admin> Admins { get; set; }

        public List<Agent> Agents { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Employee> Employees { get; set; }
    }
}

using InsuranceDay1.Models;
using InsuranceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Data
{
    public class MyContext: DbContext
    {   
        public DbSet<Admin> Admins {  get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Commision> Commisions { get; set; }

        public DbSet<CommisionWithdrawal> CommisionWithdrawals { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerInsuranceAccount> CustomerInsuranceAccounts { get; set; }

        public DbSet<Documents> Documents { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<InsurancePlan> InsurancePlans { get; set; }

        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }

        public DbSet<InsuranceType> InsuranceTypes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<PolicyClaim> PolicyClaims { get; set; }

        public DbSet<PolicyPayment> PolicyPayments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Query> Queries { get; set; }

        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
    }
}

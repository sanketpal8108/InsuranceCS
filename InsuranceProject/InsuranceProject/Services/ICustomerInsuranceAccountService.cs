using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface ICustomerInsuranceAccountService
    {
        public List<CustomerInsuranceAccount> GetAll();
        public CustomerInsuranceAccount Get(int id);
        public List<CustomerInsuranceAccount> GetByCustomerId(int customerId);
        public CustomerInsuranceAccount Check(int id);
        public int Add(CustomerInsuranceAccount customer);
        public CustomerInsuranceAccount Update(CustomerInsuranceAccount customer);
        public void Delete(CustomerInsuranceAccount customer);
        public CustomerInsuranceAccount FindByPlanId(int planId);
    }
}

using InsuranceDay1.Models;
using InsuranceProject.Pagination;

namespace InsuranceProject.Services
{
    public interface ICustomerService
    {
        public PageList<Customer> GetAll(PageParameters pageParameters);
        public Customer Get(int id);
        public bool isUniqueness(string username);
        public Customer Check(int id);
        public int Add(Customer customer);
        public Customer Update(Customer customer);
        public void Delete(Customer customer);
        public Customer FindCustomer(string username);
        public string GetRoleName(Customer customer);
    }
}

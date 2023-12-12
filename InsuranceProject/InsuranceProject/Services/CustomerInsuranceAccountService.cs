using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class CustomerInsuranceAccountService:ICustomerInsuranceAccountService
    {
        private IEntityRepository<CustomerInsuranceAccount> _entityRepository;
        private MyContext _context;
        public CustomerInsuranceAccountService(IEntityRepository<CustomerInsuranceAccount> entityRepository, MyContext context)
        {
            _entityRepository = entityRepository;
            _context = context;
        }

        public List<CustomerInsuranceAccount> GetAll()
        {
            var customerQuery = _entityRepository.Get();
            var customers = customerQuery.Where(customer => customer.IsActive).ToList();
            return customers;
        }
        public List<CustomerInsuranceAccount> GetByCustomerId(int customerId)
        {
            var customerQuery = _entityRepository.Get();
            var customers = customerQuery.Where(customer => customer.CustomerId == customerId).ToList();
            return customers;
        }

        public CustomerInsuranceAccount Get(int id)
        {
            var customerQuery = _entityRepository.Get();
            var customer = customerQuery.Where(customer => customer.Id == id).FirstOrDefault();
            return customer;
        }

        public CustomerInsuranceAccount Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(CustomerInsuranceAccount customer)
        {
            return _entityRepository.Add(customer);
        }

        public CustomerInsuranceAccount Update(CustomerInsuranceAccount customer)
        {
            return _entityRepository.Update(customer);
        }

        public void Delete(CustomerInsuranceAccount customer)
        {
            _entityRepository.Delete(customer);
        }
        public CustomerInsuranceAccount FindByPlanId(int planId)
        {
            return _context.CustomerInsuranceAccounts.Where(user => user.InsurancePlanId == planId).OrderBy(user => user.Id).LastOrDefault();
        }
    }
}

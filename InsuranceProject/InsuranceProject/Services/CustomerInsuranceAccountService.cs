using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class CustomerInsuranceAccountService:ICustomerInsuranceAccountService
    {
        private IEntityRepository<CustomerInsuranceAccount> _entityRepository;

        public CustomerInsuranceAccountService(IEntityRepository<CustomerInsuranceAccount> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<CustomerInsuranceAccount> GetAll()
        {
            var customerQuery = _entityRepository.Get();
            var customers = customerQuery.Where(customer => customer.IsActive).ToList();
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
    }
}

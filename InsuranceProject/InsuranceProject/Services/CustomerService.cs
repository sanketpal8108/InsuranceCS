using InsuranceDay1.Models;
using InsuranceProject.Repository;
using Microsoft.EntityFrameworkCore;
using InsuranceProject.Data;
using InsuranceProject.Pagination;

namespace InsuranceProject.Services
{
    public class CustomerService:ICustomerService
    {
        private IEntityRepository<Customer> _entityRepository;
        private IEntityRepository<CustomerInsuranceAccount> _customerInsuranceAccRepository;
        private IEntityRepository<Documents> _documentsRepository;
        private ICustomerInsuranceAccountService _customerInsuranceAccountService;
        private IDocumentService _documentService;
        private MyContext _context;


        public CustomerService(IEntityRepository<Customer> entityRepository, MyContext context,
            IEntityRepository<CustomerInsuranceAccount> customerInsuranceAccRepository, IEntityRepository<Documents> documentsRepository,
            ICustomerInsuranceAccountService customerInsuranceAccountService, IDocumentService documentService)
        {
            _entityRepository = entityRepository;
            _context = context;
            _customerInsuranceAccountService = customerInsuranceAccountService;
            _documentsRepository = documentsRepository;
            _documentService = documentService;
            _customerInsuranceAccRepository = customerInsuranceAccRepository;

        }
        public bool isUniqueness(string username)
        {
            var usernameExist = FindCustomer(username);
            if (usernameExist?.UserName == username)
                return false;
            return true;
        }
        public List<Customer> GetAll()
        {
            string[] innerTables = { "CustomerList" };
            var customerQuery = _entityRepository.Get();
            var customers = customerQuery.Where(customer => customer.IsActive).ToList();
            return customers;
        }

        public Customer Get(int id)
        {
            var customerQuery = _entityRepository.Get();
            var customer = customerQuery.Where(customer => customer.Id == id).FirstOrDefault();
            return customer;
        }

        public Customer Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Customer customer)
        {
            return _entityRepository.Add(customer);
        }

        public Customer Update(Customer customer)
        {
            return _entityRepository.Update(customer);
        }

        public void Delete(Customer customer)
        {
            var custInsuranceAcc= _customerInsuranceAccRepository.Get();
            var documents = _documentsRepository.Get();
            if (documents != null)
            {
                foreach (var item in documents.Where(query => query.CustomerId == customer.Id).ToList())
                {
                    _documentService.Delete(item);
                }
            }
            if (custInsuranceAcc != null)
            {
                foreach (var item in custInsuranceAcc.Where(query => query.CustomerId == customer.Id).ToList())
                {
                    _customerInsuranceAccountService.Delete(item);
                }
            }
            _entityRepository.Delete(customer);
        }
        public Customer FindCustomer(string username)
        {
            return _context.Customers.Where(user => user.UserName == username).FirstOrDefault();
        }

        public string GetRoleName(Customer customer)
        {
            return _context.Roles.Where(role => role.Id == customer.RoleId).FirstOrDefault().RoleName;
        }
    }
}

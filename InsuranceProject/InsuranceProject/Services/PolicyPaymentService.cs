
using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class PolicyPaymentService:IPolicyPaymentService
    {
        private IEntityRepository<PolicyPayment> _entityRepository;
        public PolicyPaymentService(IEntityRepository<PolicyPayment> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<PolicyPayment> GetAll()
        {
            var policyPaymentQuery = _entityRepository.Get();
            return policyPaymentQuery.Where(policyPayment => policyPayment.IsActive).ToList();
        }
        public PolicyPayment Get(int id)
        {
            var policyPaymentQuery = _entityRepository.Get();
            return policyPaymentQuery.Where(policyPayment => policyPayment.IsActive && policyPayment.Id == id).FirstOrDefault();
        }
        public int Add(PolicyPayment policyPayment)
        {
            return _entityRepository.Add(policyPayment);
        }
        public PolicyPayment Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public PolicyPayment Update(PolicyPayment policyPayment)
        {
            return _entityRepository.Update(policyPayment);
        }
        public void Delete(PolicyPayment policyPayment)
        {
            _entityRepository.Delete(policyPayment);
        }
    }
}

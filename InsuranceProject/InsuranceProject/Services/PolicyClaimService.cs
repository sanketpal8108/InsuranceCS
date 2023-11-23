
using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class PolicyClaimService:IPolicyClaimService
    {
        private IEntityRepository<PolicyClaim> _entityRepository;
        public PolicyClaimService(IEntityRepository<PolicyClaim> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<PolicyClaim> GetAll()
        {
            var policyClaimQuery = _entityRepository.Get();
            return policyClaimQuery.Where(policyClaim => policyClaim.IsActive).ToList();
        }
        public PolicyClaim Get(int id)
        {
            var policyClaimQuery = _entityRepository.Get();
            return policyClaimQuery.Where(policyClaim => policyClaim.IsActive && policyClaim.Id == id).FirstOrDefault();
        }
        public int Add(PolicyClaim policyClaim)
        {
            return _entityRepository.Add(policyClaim);
        }
        public PolicyClaim Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public PolicyClaim Update(PolicyClaim policyClaim)
        {
            return _entityRepository.Update(policyClaim);
        }
        public void Delete(PolicyClaim policyClaim)
        {
            _entityRepository.Delete(policyClaim);
        }
    }
}

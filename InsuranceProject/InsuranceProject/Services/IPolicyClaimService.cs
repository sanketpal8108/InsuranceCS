using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface IPolicyClaimService
    {
        public List<PolicyClaim> GetAll();
        public PolicyClaim Get(int id);
        public int Add(PolicyClaim policyClaim);
        public PolicyClaim Check(int id);
        public PolicyClaim Update(PolicyClaim policyClaim);
        public void Delete(PolicyClaim policyClaim);
    }
}

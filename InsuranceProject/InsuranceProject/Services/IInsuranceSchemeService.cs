using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface IInsuranceSchemeService
    {
        public List<InsuranceScheme> GetAll();
        public InsuranceScheme Get(int id);
        public int Add(InsuranceScheme insuranceScheme);
        public InsuranceScheme Check(int id);
        public InsuranceScheme Update(InsuranceScheme insuranceScheme);
        public void Delete(InsuranceScheme insuranceScheme);
    }
}

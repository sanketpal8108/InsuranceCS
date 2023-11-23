using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface IInsurancePlanService
    {
        public List<InsurancePlan> GetAll();
        public InsurancePlan Get(int id);
        public int Add(InsurancePlan insurancePlan);
        public InsurancePlan Check(int id);
        public InsurancePlan Update(InsurancePlan insurancePlan);
        public void Delete(InsurancePlan insurancePlan);
    }
}

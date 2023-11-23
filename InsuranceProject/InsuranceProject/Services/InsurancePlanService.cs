
using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class InsurancePlanService:IInsurancePlanService
    {
        private IEntityRepository<InsurancePlan> _entityRepository;
        public InsurancePlanService(IEntityRepository<InsurancePlan> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<InsurancePlan> GetAll()
        {
            var insurancePlanQuery = _entityRepository.Get();
            return insurancePlanQuery.Where(insurancePlan => insurancePlan.IsActive).ToList();
        }
        public InsurancePlan Get(int id)
        {
            var insurancePlanQuery = _entityRepository.Get();
            return insurancePlanQuery.Where(insurancePlan => insurancePlan.IsActive && insurancePlan.Id == id).FirstOrDefault();
        }
        public int Add(InsurancePlan insurancePlan)
        {
            return _entityRepository.Add(insurancePlan);
        }
        public InsurancePlan Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public InsurancePlan Update(InsurancePlan insurancePlan)
        {
            return _entityRepository.Update(insurancePlan);
        }
        public void Delete(InsurancePlan insurancePlan)
        {
            _entityRepository.Delete(insurancePlan);
        }
    }
}

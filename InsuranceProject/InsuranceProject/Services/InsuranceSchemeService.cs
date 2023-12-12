
using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    
    public class InsuranceSchemeService:IInsuranceSchemeService
    {
        private IEntityRepository<InsuranceScheme> _entityRepository;
        private IEntityRepository<InsurancePlan> _insurancePlanRepository;
        private IInsurancePlanService _insurancePlanService;
        private MyContext _context;
        public InsuranceSchemeService(IEntityRepository<InsuranceScheme> entityRepository, IEntityRepository<InsurancePlan> insurancePlanRepository,
            MyContext context, IInsurancePlanService insurancePlanService)
        {
            _entityRepository = entityRepository;
            _insurancePlanRepository = insurancePlanRepository;
            _insurancePlanService = insurancePlanService;
            _context = context;
        }
        public List<InsuranceScheme> GetAll()
        {
            var insuranceSchemeQuery = _entityRepository.Get();
            return insuranceSchemeQuery.Where(insuranceScheme => insuranceScheme.IsActive).ToList();
        }
        public InsuranceScheme Get(int id)
        {
            var insuranceSchemeQuery = _entityRepository.Get();
            return insuranceSchemeQuery.Where(insuranceScheme => insuranceScheme.IsActive && insuranceScheme.Id == id).FirstOrDefault();
        }
        public int Add(InsuranceScheme insuranceScheme)
        {
            return _entityRepository.Add(insuranceScheme);
        }
        public InsuranceScheme Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public InsuranceScheme Update(InsuranceScheme insuranceScheme)
        {
            return _entityRepository.Update(insuranceScheme);
        }
        public void Delete(InsuranceScheme insuranceScheme)
        {
            var insurancePlanQuery= _insurancePlanRepository.Get();
            foreach (var item in insurancePlanQuery.Where(query=>query.InsuranceSchemeId==insuranceScheme.Id).ToList())
            {
                _insurancePlanService.Delete(item);
            }
            _entityRepository.Delete(insuranceScheme);
        }
        public InsuranceScheme FindScheme(string username)
        {
            return _context.InsuranceSchemes.Where(user => user.InsuranceSchemeName == username).FirstOrDefault();
        }
        public bool IsUniqueness(string username)
        {
            var usernameExist = FindScheme(username);
            if (usernameExist?.InsuranceSchemeName == username)
                return false;
            return true;
        }
    }
}

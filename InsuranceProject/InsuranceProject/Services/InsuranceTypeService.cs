
using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class InsuranceTypeService:IInsuranceTypeService
    {
        private IEntityRepository<InsuranceType> _entityRepository;
        private IEntityRepository<InsuranceScheme> _insuranceSchemeRepository;
        private IInsuranceSchemeService _insuranceSchemeService;
        private MyContext _context;
        public InsuranceTypeService(IEntityRepository<InsuranceType> entityRepository, IEntityRepository<InsuranceScheme> insuranceSchemeRepository,
            MyContext context,IInsuranceSchemeService insuranceSchemeService)
        {
            _entityRepository = entityRepository;
            _insuranceSchemeRepository = insuranceSchemeRepository;
            _insuranceSchemeService = insuranceSchemeService;
            _context = context;
        }
        public List<InsuranceType> GetAll()
        {
            var insuranceTypeQuery = _entityRepository.Get();
            return insuranceTypeQuery.Where(insuranceType => insuranceType.IsActive).ToList();
        }
        public InsuranceType Get(int id)
        {
            var insuranceTypeQuery = _entityRepository.Get();
            return insuranceTypeQuery.Where(insuranceType => insuranceType.IsActive && insuranceType.Id == id).FirstOrDefault();
        }
        public int Add(InsuranceType insuranceType)
        {
            return _entityRepository.Add(insuranceType);
        }
        public InsuranceType Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public InsuranceType Update(InsuranceType insuranceType)
        {
            return _entityRepository.Update(insuranceType);
        }
        public void Delete(InsuranceType insuranceType)
        {
            var insuranceSchemeQuery= _insuranceSchemeRepository.Get();
            foreach (var item in insuranceSchemeQuery.Where(query=>query.InsuranceTypeId==insuranceType.Id).ToList())
            {
                _insuranceSchemeService.Delete(item);
            }
            _entityRepository.Delete(insuranceType);
        }
        public InsuranceType FindType(string username)
        {
            return _context.InsuranceTypes.Where(user => user.InsuranceTypeName == username).FirstOrDefault();
        }
        public bool IsUniqueness(string username)
        {
            var usernameExist = FindType(username);
            if (usernameExist?.InsuranceTypeName == username)
                return false;
            return true;
        }
    }
}

using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface IInsuranceTypeService
    {
        public List<InsuranceType> GetAll();
        public InsuranceType Get(int id);
        public int Add(InsuranceType insuranceType);
        public InsuranceType Check(int id);
        public InsuranceType Update(InsuranceType insuranceType);
        public void Delete(InsuranceType insuranceType);
    }
}

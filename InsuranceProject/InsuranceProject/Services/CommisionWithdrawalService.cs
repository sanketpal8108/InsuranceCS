using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class CommisionWithdrawalService:ICommisionWithdrawalService
    {
        private IEntityRepository<CommisionWithdrawal> _entityRepository;

        public CommisionWithdrawalService(IEntityRepository<CommisionWithdrawal> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<CommisionWithdrawal> GetAll()
        {
            var commisionWithQuery = _entityRepository.Get();
            var commisionWiths= commisionWithQuery.Where(comm=>comm.IsActive).ToList();
            return commisionWiths;
        }

        public CommisionWithdrawal Get(int id)
        {
            var commisionWithQuery = _entityRepository.Get();
            var commisionWith = commisionWithQuery.Where(commision => commision.Id == id).FirstOrDefault();
            return commisionWith;
        }

        public CommisionWithdrawal Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(CommisionWithdrawal commisionWithdrawal)
        {
            return _entityRepository.Add(commisionWithdrawal);
        }

        public CommisionWithdrawal Update(CommisionWithdrawal commisionWithdrawal)
        {
            return _entityRepository.Update(commisionWithdrawal);
        }

        public void Delete(CommisionWithdrawal commisionWithdrawal)
        {
            _entityRepository.Delete(commisionWithdrawal);
        }
    }
}

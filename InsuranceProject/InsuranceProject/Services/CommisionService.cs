using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class CommisionService:ICommisionService
    {
        private IEntityRepository<Commision> _entityRepository;

        public CommisionService(IEntityRepository<Commision> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Commision> GetAll()
        {
            var commisionQuery = _entityRepository.Get();
            var commisions = commisionQuery.Where(commision => commision.IsActive).ToList();
            return commisions;
        }

        public Commision Get(int id)
        {
            var commisionQuery = _entityRepository.Get();
            var commision = commisionQuery.Where(commision => commision.Id == id).FirstOrDefault();
            return commision;
        }

        public Commision Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Commision commision)
        {
            return _entityRepository.Add(commision);
        }

        public Commision Update(Commision commision)
        {
            return _entityRepository.Update(commision);
        }

        public void Delete(Commision commision)
        {
            _entityRepository.Delete(commision);
        }
    }
}

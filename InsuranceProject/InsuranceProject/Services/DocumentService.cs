using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class DocumentService:IDocumentService
    {
        private IEntityRepository<Documents> _entityRepository;

        public DocumentService(IEntityRepository<Documents> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public List<Documents> GetAll()
        {
            var documentQuery = _entityRepository.Get();
            var documents = documentQuery.Where(document => document.IsActive).ToList();
            return documents;
        }

        public Documents Get(int id)
        {
            var documentQuery = _entityRepository.Get();
            var document = documentQuery.Where(document => document.Id == id).FirstOrDefault();
            return document;
        }

        public Documents Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Documents document)
        {
            return _entityRepository.Add(document);
        }

        public Documents Update(Documents document)
        {
            return _entityRepository.Update(document);
        }

        public void Delete(Documents document)
        {
            _entityRepository.Delete(document);
        }
    }
}

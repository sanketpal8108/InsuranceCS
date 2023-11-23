using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface IDocumentService
    {
        public List<Documents> GetAll();
        public Documents Get(int id);

        public Documents Check(int id);
        public int Add(Documents document);
        public Documents Update(Documents document);
        public void Delete(Documents document);
    }
}

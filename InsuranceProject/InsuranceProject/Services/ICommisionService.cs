using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface ICommisionService
    {
        public List<Commision> GetAll();

        public Commision Get(int id);
        public Commision Check(int id);
        public int Add(Commision commision);
        public Commision Update(Commision commision);
        public void Delete(Commision commision);

    }
}

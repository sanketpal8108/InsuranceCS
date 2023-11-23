using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface ICommisionWithdrawalService
    {
        public List<CommisionWithdrawal> GetAll();
        public CommisionWithdrawal Get(int id);
        public CommisionWithdrawal Check(int id);

        public int Add(CommisionWithdrawal commisionWithdrawal);

        public CommisionWithdrawal Update(CommisionWithdrawal commisionWithdrawal);

        public void Delete(CommisionWithdrawal commisionWithdrawal);
    }
}

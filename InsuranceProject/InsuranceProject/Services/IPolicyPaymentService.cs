using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface IPolicyPaymentService
    {
        public List<PolicyPayment> GetAll();
        public PolicyPayment Get(int id);
        public int Add(PolicyPayment policyPayment);
        public PolicyPayment Check(int id);
        public PolicyPayment Update(PolicyPayment policyPayment);
        public void Delete(PolicyPayment policyPayment);


    }
}

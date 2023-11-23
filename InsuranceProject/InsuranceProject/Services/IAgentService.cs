using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface IAgentService
    {
        public List<Agent> GetAll();
        public Agent Get(int id);
        public Agent Check(int id);
        public int Add(Agent agent);
        public Agent Update(Agent agent);
        public void Delete(Agent agent);
        public bool IsUniqueness(string username);

        public Agent FindAgent(string username);

        public string GetRoleName(Agent agent);

    }
}

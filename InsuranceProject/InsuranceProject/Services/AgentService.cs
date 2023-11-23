using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class AgentService:IAgentService
    {
        private IEntityRepository<Agent> _entityRepository;
        private IEntityRepository<Commision> _commisionRepository;
        private ICommisionService _commisionService;
        private MyContext _context;

        public AgentService(IEntityRepository<Agent> entityRepository,
            MyContext context,IEntityRepository<Commision> commisionRepository,
            ICommisionService commisionService)
        {
            _entityRepository = entityRepository;
            _context = context;
            _commisionRepository = commisionRepository;
            _commisionService = commisionService;
        }

        public List<Agent> GetAll()
        {
            var agentQuery = _entityRepository.Get();
            var agents = agentQuery.Where(agent => agent.IsActive).ToList();
            return agents;
        }
        public bool IsUniqueness(string username)
        {
            var usernameExist = FindAgent(username);
            if (usernameExist?.UserName == username)
                return false;
            return true;
        }

        public Agent Get(int id)
        {
            var agentQuery = _entityRepository.Get();
            var agent = agentQuery.Where(agent => agent.Id == id).FirstOrDefault();
            return agent;
        }

        public Agent Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Agent agent)
        {
            return _entityRepository.Add(agent);
        }

        public Agent Update(Agent agent)
        {
            return _entityRepository.Update(agent);
        }

        public void Delete(Agent agent)
        {
            var commisions= _commisionRepository.Get();
            foreach (var item in commisions.Where(query=>query.AgentId==agent.Id).ToList())
            {
                _commisionService.Delete(item);
            }
            _entityRepository.Delete(agent);
        }

        public Agent FindAgent(string username)
        {
            return _context.Agents.Where(user => user.UserName == username).FirstOrDefault();
        }

        public string GetRoleName(Agent agent)
        {
            return _context.Roles.Where(role => role.Id == agent.RoleId).FirstOrDefault().RoleName;
        }

    }
}

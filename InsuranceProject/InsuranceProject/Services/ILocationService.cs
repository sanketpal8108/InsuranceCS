using InsuranceDay1.Models;

namespace InsuranceProject.Service
{
    public interface ILocationService
    {
        public List<Location> GetAll();
        public Location Get(int id);
        public int Add(Location location);
        public Location Check(int id);
        public Location Update(Location location);
        public void Delete(Location location);
    }
}

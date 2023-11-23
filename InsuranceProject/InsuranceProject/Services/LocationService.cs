
using InsuranceDay1.Models;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class LocationService:ILocationService
    {
        private IEntityRepository<Location> _entityRepository;
        public LocationService(IEntityRepository<Location> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public List<Location> GetAll()
        {
            var locationQuery = _entityRepository.Get();
            return locationQuery.Where(location => location.IsActive).ToList();
        }
        public Location Get(int id)
        {
            var locationQuery = _entityRepository.Get();
            return locationQuery.Where(location => location.IsActive && location.Id == id).FirstOrDefault();
        }
        public int Add(Location location)
        {
            return _entityRepository.Add(location);
        }
        public Location Check(int id)
        {
            return _entityRepository.Get(id);
        }
        public Location Update(Location location)
        {
            return _entityRepository.Update(location);
        }
        public void Delete(Location location)
        {
            _entityRepository.Delete(location);
        }
    }
}

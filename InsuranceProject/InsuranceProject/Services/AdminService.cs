using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class AdminService:IAdminService
    {
        private IEntityRepository<Admin> _entityRepository;
        private MyContext _context;

        public AdminService(IEntityRepository<Admin> entityRepository,MyContext myContext)
        {
            _entityRepository = entityRepository;
            _context = myContext;
        }
        
        public List<Admin> GetAll()
        {
            var adminQuery = _entityRepository.Get();
            var admins=adminQuery.Where(admin=>admin.IsActive).ToList();
            return admins;
        }

        public Admin Get(int id)
        {
            var adminQuery= _entityRepository.Get();
            var admin=adminQuery.Where(admin=>admin.Id==id).FirstOrDefault();
            return admin;
        }

        public Admin Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Admin admin)
        {
            return _entityRepository.Add(admin);
        }

        public Admin Update(Admin admin)
        {
            return _entityRepository.Update(admin);
        }

        public void Delete(Admin admin)
        {
            _entityRepository.Delete(admin);
        }

        public Admin FindAdmin(string username)
        {
            return _context.Admins.Where(user => user.UserName == username).FirstOrDefault();
        }

        public string GetRoleName(Admin admin)
        {
            return _context.Roles.Where(role => role.Id == admin.RoleId).FirstOrDefault().RoleName;
        }
    }
}

using InsuranceDay1.Models;
using InsuranceProject.Data;
using InsuranceProject.Repository;

namespace InsuranceProject.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IEntityRepository<Employee> _entityRepository;
        private MyContext _context;

        public EmployeeService(IEntityRepository<Employee> entityRepository, MyContext context)
        {
            _entityRepository = entityRepository;
            _context = context;
        }
        public bool isUniqueness(string username)
        {
            var usernameExist = FindEmployee(username);
            if (usernameExist?.UserName == username)
                return false;
            return true;
        }
        public List<Employee> GetAll()
        {
            var empolyeeQuery = _entityRepository.Get();
            var employees = empolyeeQuery.Where(employee => employee.IsActive).ToList();
            return employees;
        }

        public Employee Get(int id)
        {
            var employeeQuery = _entityRepository.Get();
            var employee = employeeQuery.Where(employee => employee.Id == id).FirstOrDefault();
            return employee;
        }

        public Employee Check(int id)
        {
            return _entityRepository.Get(id);
        }

        public int Add(Employee employee)
        {
            return _entityRepository.Add(employee);
        }

        public Employee Update(Employee employee)
        {
            return _entityRepository.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _entityRepository.Delete(employee);
        }
        public Employee FindEmployee(string username)
        {
            return _context.Employees.Where(user => user.UserName == username).FirstOrDefault();
        }

        public string GetRoleName(Employee employee)
        {
            return _context.Roles.Where(role => role.Id == employee.RoleId).FirstOrDefault().RoleName;
        }
    }
}

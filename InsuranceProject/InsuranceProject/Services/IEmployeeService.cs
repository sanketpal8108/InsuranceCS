using InsuranceDay1.Models;

namespace InsuranceProject.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public Employee Get(int id);
        public bool isUniqueness(string username);
        public Employee Check(int id);

        public int Add(Employee employee);

        public Employee Update(Employee employee);

        public void Delete(Employee employee);

        public Employee FindEmployee(string username);

        public string GetRoleName(Employee employee);

    }
}

using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Services;
using InsuranceProject.Token_Creation;
using LoginAuthDemo.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private IConfiguration _configuration;
        public EmployeeController(IEmployeeService employeeService,IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employeeDTO = new List<EmployeeDto>();
            var employees = _employeeService.GetAll();
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    employeeDTO.Add(ConvertToDTO(employee));
                }
                return Ok(employeeDTO);
            }
            throw new EntityNotFoundError("Employee not found");
        }
        [HttpGet("UsernameUnique")]

        public IActionResult isUnique(string username)
        {
            bool isunique = _employeeService.isUniqueness(username);
            return Ok(isunique);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
            {
                throw new EntityNotFoundError("Employee not found");
            }
            return Ok(ConvertToDTO(employee));
        }
        [HttpPost]
        public IActionResult Add(EmployeeDto employeeDto)
        {
            var employee = ConvertToModel(employeeDto);
            employee.Password = BCrypt.Net.BCrypt.HashPassword(employeeDto.Password);
            var employeeId = _employeeService.Add(employee);
            if (employeeId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(employeeId);
        }
        [HttpPut]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            var employeeDTOToUpdate = _employeeService.Check(employeeDto.Id);
            if (employeeDTOToUpdate != null)
            {
                var updatedEmployee = ConvertToModel(employeeDto);
                var modifiedEmployee = _employeeService.Update(updatedEmployee);
                return Ok(ConvertToDTO(modifiedEmployee));
            }
            throw new EntityNotFoundError("No Employee found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee != null)
            {
                _employeeService.Delete(employee);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Employee found to delete");
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto employeeDto)
        {
            var employee = _employeeService.FindEmployee(employeeDto.UserName);
            //admin.RoleId = 1;
            var role = _employeeService.GetRoleName(employee);
            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(employeeDto.Password, employee.Password))
                {
                    //return Ok("Login Successful");
                    string jwt = CreateToken<Employee>.CreateTokens(employee.UserName, role, _configuration);
                    Response.Headers.Add("Jwt", JsonConvert.SerializeObject(jwt));
                    //return Ok(JsonConvert.SerializeObject(_userService.GetRoleName(user)));
                    return Ok(new LoginResponseDto()
                    {
                        UserId = employee.Id,
                        UserName = employee.UserName,
                        RoleName = role
                    });
                }
            }
            return BadRequest("UserName/Password dosesnt exist");
        }
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var employee = _employeeService.Get(changePasswordDto.Id);
            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, employee.Password))
                {
                    employee.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
                    _employeeService.Update(employee);
                    return Ok(1);
                }
                return BadRequest("Old Password Does Not Match");
            }
            return BadRequest("Employee Not Found");
        }
        private Employee ConvertToModel(EmployeeDto employeeDto)
        {
            return new Employee()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                UserName = employeeDto.UserName,
                Password = employeeDto.Password,
                IsActive = true,
                RoleId = 4,

            };
        }
        private EmployeeDto ConvertToDTO(Employee employee)
        {
            return new EmployeeDto()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                UserName = employee.UserName,
                Password = employee.Password,
                //RoleId= employee.RoleId,


            };
        }
    }
}

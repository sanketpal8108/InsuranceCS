using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Service;
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
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        private IConfiguration _configuration;

        //forCount
        private IAgentService _agentService;
        private IEmployeeService _employeeService;
        private ICustomerService _customerService;
        private IInsuranceTypeService _insuranceTypeService;
        private IInsuranceSchemeService _insuranceSchemeService;
        private ILocationService _locationService;
        public AdminController(IAdminService adminService, IConfiguration configuration)
        {
            _adminService = adminService;
            _configuration = configuration;

        }
        //[HttpGet("GetCount")]
        //public IActionResult GetCount()
        //{
        //    //var countData = new CountData(_agentService, _employeeService, _customerService, _insuranceTypeService,
        //    //    _locationService, _insuranceSchemeService);
        //    Dictionary<string, int> count = new Dictionary<string, int>()
        //    {
        //        { "agentCount",_agentService.GetAll().Count()},
        //        {"employeeCount" ,_employeeService.GetAll().Count()},
        //        {"customerCount" , _customerService.GetAll().Count()},
        //        {"insuranceTypeCount",_insuranceTypeService.GetAll().Count() },
        //        {"insuranceSchemeCount",_insuranceSchemeService.GetAll().Count() },
        //        {"locationCount",_locationService.GetAll().Count() },

        //    };
        //    return Ok(count);

        //}
        [HttpGet]
        public IActionResult Get()
        {
            var adminDTO = new List<AdminDto>();
            var admins = _adminService.GetAll();
            if (admins.Count > 0)
            {
                foreach (var admin in admins)
                {
                    adminDTO.Add(ConvertToDTO(admin));
                }
                return Ok(adminDTO);
            }
            throw new  EntityNotFoundError("Admins not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var admin = _adminService.Get(id);
            if (admin == null)
            {
                throw new  EntityNotFoundError("Admin not found");
            }
            return Ok(ConvertToDTO(admin));
        }
        [HttpPost]
        public IActionResult Add(AdminDto adminDto)
        {
            var admin = ConvertToModel(adminDto);
            admin.Password = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);
            var AdminId = _adminService.Add(admin);
            if (AdminId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(AdminId);
        }
        [HttpPut]
        public IActionResult Update(AdminDto adminDto)
        {
            var adminDTOToUpdate = _adminService.Check(adminDto.Id);
            if (adminDTOToUpdate != null)
            {
                var updatedAdmin = ConvertToModel(adminDto);
                var modifiedAdmin = _adminService.Update(updatedAdmin);
                return Ok(ConvertToDTO(modifiedAdmin));
            }
            throw new EntityNotFoundError("No Admin found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var agent = _adminService.Get(id);
            if (agent != null)
            {
                _adminService.Delete(agent);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Admin found to delete");
        }

        [HttpPost("Login")]

        public IActionResult Login(LoginDto adminDto)
        {
            var admin = _adminService.FindAdmin(adminDto.UserName);
            //admin.RoleId = 1;
            var role = _adminService.GetRoleName(admin);
            if (admin != null)
            {
                if (BCrypt.Net.BCrypt.Verify(adminDto.Password, admin.Password))
                {
                    //return Ok("Login Successful");
                    string jwt = CreateToken<Admin>.CreateTokens(admin.UserName,role,_configuration);
                    Response.Headers.Add("Jwt", JsonConvert.SerializeObject(jwt));
                    //return Ok(JsonConvert.SerializeObject(_userService.GetRoleName(user)));
                    return Ok(new LoginResponseDto()
                    {
                        UserId = admin.Id,
                        UserName = admin.UserName,
                        RoleName = role
                    });
                }
            }
            return BadRequest("UserName/Password dosesnt exist");
        }
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var admin = _adminService.Get(changePasswordDto.Id);
            if (admin != null)
            {
                if (BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, admin.Password))
                {
                    admin.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
                    _adminService.Update(admin);
                    return Ok(1);
                }
                return BadRequest("Old Password Does Not Match");
            }
            return BadRequest("Admin Not Found");
        }
        private Admin ConvertToModel(AdminDto agentDto)
        {
            return new Admin()
            {
                Id = agentDto.Id,
                FirstName = agentDto.FirstName,
                LastName = agentDto.LastName,
                UserName = agentDto.UserName,
                Password = agentDto.Password,
                RoleId = 1,
                IsActive = true

            };
        }
        private AdminDto ConvertToDTO(Admin admin)
        {
            return new AdminDto()
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                UserName = admin.UserName,
                Password = admin.Password,
               //RoleId= admin.RoleId,

            };
        }
    }
}

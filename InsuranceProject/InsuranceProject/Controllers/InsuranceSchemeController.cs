using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Service;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceSchemeController : ControllerBase
    {
        private IInsuranceSchemeService _insuranceSchemeService;
        public InsuranceSchemeController(IInsuranceSchemeService insuranceSchemeService)
        {
            _insuranceSchemeService = insuranceSchemeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var insuranceSchemeDTO = new List<InsuranceSchemeDto>();
            var insuranceSchemes = _insuranceSchemeService.GetAll();
            if (insuranceSchemes.Count > 0)
            {
                foreach (var insuranceScheme in insuranceSchemes)
                {
                    insuranceSchemeDTO.Add(ConvertToDTO(insuranceScheme));
                }
                return Ok(insuranceSchemeDTO);
            }
            throw new EntityNotFoundError("InsuranceScheme not found");
        }
        [HttpGet("Unique/{Name}")]
        public IActionResult isUnique(string Name)
        {
            bool isunique = _insuranceSchemeService.IsUniqueness(Name);
            return Ok(isunique);
        }
        [HttpGet("FindType/{Name}")]
        public IActionResult FindType(string Name)
        {
            var plan = _insuranceSchemeService.FindScheme(Name);
            if (plan != null)
                return Ok(ConvertToDTO(plan));
            return NotFound($"Plan with planName {Name} not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var insuranceScheme = _insuranceSchemeService.Get(id);
            if (insuranceScheme == null)
            {
                throw new EntityNotFoundError("InsuranceScheme not found");
            }
            return Ok(ConvertToDTO(insuranceScheme));
        }
        [HttpPost]
        public IActionResult Add(InsuranceSchemeDto insuranceSchemeDto)
        {
            var insuranceScheme = ConvertToModel(insuranceSchemeDto);
            var insuranceSchemeId = _insuranceSchemeService.Add(insuranceScheme);
            if (insuranceSchemeId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(insuranceSchemeId);
        }
        [HttpPut]
        public IActionResult Update(InsuranceSchemeDto insuranceSchemeDto)
        {
            var insuranceSchemeDTOToUpdate = _insuranceSchemeService.Check(insuranceSchemeDto.Id);
            if (insuranceSchemeDTOToUpdate != null)
            {
                var updatedInsuranceScheme = ConvertToModel(insuranceSchemeDto);
                var modifiedInsuranceScheme = _insuranceSchemeService.Update(updatedInsuranceScheme);
                return Ok(ConvertToDTO(modifiedInsuranceScheme));
            }
            throw new EntityNotFoundError("No InsuranceScheme found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var insuranceScheme = _insuranceSchemeService.Get(id);
            if (insuranceScheme != null)
            {
                _insuranceSchemeService.Delete(insuranceScheme);
                return Ok(id);
            }
            throw new EntityNotFoundError("No InsuranceScheme found to delete");
        }
        private InsuranceScheme ConvertToModel(InsuranceSchemeDto insuranceSchemeDto)
        {
            return new InsuranceScheme()
            {
                Id = insuranceSchemeDto.Id,
                InsuranceTypeId = insuranceSchemeDto.InsuranceTypeId,
                InsuranceSchemeName = insuranceSchemeDto.InsuranceSchemeName,
                //InsuranceSchemeImage = insuranceSchemeDto.InsuranceSchemeImage,
                InstallmentPaymentCommision = insuranceSchemeDto.InstallmentPaymentCommision,
                NewRegistrastionCommision = insuranceSchemeDto.NewRegistrastionCommision,
                Details = insuranceSchemeDto.Details,
                
                IsActive = true

            };
        }
        private InsuranceSchemeDto ConvertToDTO(InsuranceScheme insuranceScheme)
        {
            return new InsuranceSchemeDto()
            {
                Id = insuranceScheme.Id,
                InsuranceSchemeName = insuranceScheme.InsuranceSchemeName,
                //InsuranceSchemeImage = insuranceScheme.InsuranceSchemeImage,
                InstallmentPaymentCommision = insuranceScheme.InstallmentPaymentCommision,
                InsuranceTypeId = insuranceScheme.InsuranceTypeId,
                Details = insuranceScheme.Details,
                NewRegistrastionCommision = insuranceScheme.NewRegistrastionCommision
            };
        }
    }
}

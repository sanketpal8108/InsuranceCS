using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Service;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceTypeController : ControllerBase
    {
        private IInsuranceTypeService _insuranceTypeService;
        public InsuranceTypeController(IInsuranceTypeService insuranceTypeService)
        {
            _insuranceTypeService = insuranceTypeService;
        }
        [HttpGet/*,Authorize(Roles ="Admin")*/]
        public IActionResult Get()
        {
            var insuranceTypeDTO = new List<InsuranceTypeDto>();
            var insuranceTypes = _insuranceTypeService.GetAll();
            if (insuranceTypes.Count > 0)
            {
                foreach (var insuranceType in insuranceTypes)
                {
                    insuranceTypeDTO.Add(ConvertToDTO(insuranceType));
                }
                return Ok(insuranceTypeDTO);
            }
            throw new EntityNotFoundError("InsuranceType not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var insuranceType = _insuranceTypeService.Get(id);
            if (insuranceType == null)
            {
                throw new EntityNotFoundError("InsuranceType not found");
            }
            return Ok(ConvertToDTO(insuranceType));
        }
        [HttpPost]
        public IActionResult Add(InsuranceTypeDto insuranceTypeDto)
        {
            var insuranceType = ConvertToModel(insuranceTypeDto);
            var insuranceTypeId = _insuranceTypeService.Add(insuranceType);
            if (insuranceTypeId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(insuranceTypeId);
        }
        [HttpPut]
        public IActionResult Update(InsuranceTypeDto insuranceTypeDto)
        {
            var insuranceTypeDTOToUpdate = _insuranceTypeService.Check(insuranceTypeDto.Id);
            if (insuranceTypeDTOToUpdate != null)
            {
                var updatedInsuranceType = ConvertToModel(insuranceTypeDto);
                var modifiedInsuranceType = _insuranceTypeService.Update(updatedInsuranceType);
                return Ok(ConvertToDTO(modifiedInsuranceType));
            }
            throw new EntityNotFoundError("No InsuranceType found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var insuranceType = _insuranceTypeService.Get(id);
            if (insuranceType != null)
            {
                _insuranceTypeService.Delete(insuranceType);
                return Ok(id);
            }
            throw new EntityNotFoundError("No InsuranceType found to delete");
        }
        private InsuranceType ConvertToModel(InsuranceTypeDto insuranceTypeDto)
        {
            return new InsuranceType()
            {
                Id=insuranceTypeDto.Id,
                InsuranceTypeName=insuranceTypeDto.InsuranceTypeName,
                
                IsActive = true

            };
        }
        private InsuranceTypeDto ConvertToDTO(InsuranceType insuranceType)
        {
            return new InsuranceTypeDto()
            {
                Id= insuranceType.Id,
                InsuranceTypeName = insuranceType.InsuranceTypeName,
            };
        }
    }
}

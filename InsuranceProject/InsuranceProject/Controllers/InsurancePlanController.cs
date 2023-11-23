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
    public class InsurancePlanController : ControllerBase
    {
        private IInsurancePlanService _insurancePlanService;
        public InsurancePlanController(IInsurancePlanService insurancePlanService)
        {
            _insurancePlanService = insurancePlanService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var insurancePlanDTO = new List<InsurancePlanDto>();
            var insurancePlans = _insurancePlanService.GetAll();
            if (insurancePlans.Count > 0)
            {
                foreach (var insurancePlan in insurancePlans)
                {
                    insurancePlanDTO.Add(ConvertToDTO(insurancePlan));
                }
                return Ok(insurancePlanDTO);
            }
            throw new EntityNotFoundError("InsurancePlan not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var insurancePlan = _insurancePlanService.Get(id);
            if (insurancePlan == null)
            {
                throw new EntityNotFoundError("InsurancePlan not found");
            }
            return Ok(ConvertToDTO(insurancePlan));
        }
        [HttpPost]
        public IActionResult Add(InsurancePlanDto insurancePlanDto)
        {
            var insurancePlan = ConvertToModel(insurancePlanDto);
            var insurancePlanId = _insurancePlanService.Add(insurancePlan);
            if (insurancePlanId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(insurancePlanId);
        }
        [HttpPut]
        public IActionResult Update(InsurancePlanDto insurancePlanDto)
        {
            var insurancePlanDTOToUpdate = _insurancePlanService.Check(insurancePlanDto.Id);
            if (insurancePlanDTOToUpdate != null)
            {
                var updatedInsurancePlan = ConvertToModel(insurancePlanDto);
                var modifiedInsurancePlan = _insurancePlanService.Update(updatedInsurancePlan);
                return Ok(ConvertToDTO(modifiedInsurancePlan));
            }
            throw new EntityNotFoundError("No InsurancePlan found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var insurancePlan = _insurancePlanService.Get(id);
            if (insurancePlan != null)
            {
                _insurancePlanService.Delete(insurancePlan);
                return Ok(id);
            }
            throw new EntityNotFoundError("No InsurancePlan found to delete");
        }
        private InsurancePlan ConvertToModel(InsurancePlanDto insurancePlanDto)
        {
            return new InsurancePlan()
            {
                Id= insurancePlanDto.Id,
                InsuranceSchemeId = insurancePlanDto.InsuranceSchemeId,
                MinAge = insurancePlanDto.MinAge,
                MaxAge = insurancePlanDto.MaxAge,
                MinInvestmentAmount = insurancePlanDto.MinInvestmentAmount,
                MaxInvestmentAmount = insurancePlanDto.MaxInvestmentAmount,
                MinPolicyTerm = insurancePlanDto.MinPolicyTerm,
                MaxPolicyTerm = insurancePlanDto.MaxPolicyTerm,
                ProfitRatioPercentage = insurancePlanDto.ProfitRatioPercentage,

                IsActive = true

            };
        }
        private InsurancePlanDto ConvertToDTO(InsurancePlan insurancePlan)
        {
            return new InsurancePlanDto()
            {
                Id = insurancePlan.Id,
                InsuranceSchemeId = insurancePlan.InsuranceSchemeId,
                MinAge = insurancePlan.MinAge,
                MaxAge = insurancePlan.MaxAge,
                MinPolicyTerm = insurancePlan.MinPolicyTerm,
                MaxPolicyTerm = insurancePlan.MaxPolicyTerm,
                MinInvestmentAmount= insurancePlan.MinInvestmentAmount,
                MaxInvestmentAmount = insurancePlan.MaxInvestmentAmount,
                ProfitRatioPercentage = insurancePlan.ProfitRatioPercentage,

            };
        }
    }
}

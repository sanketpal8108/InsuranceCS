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
    public class PolicyClaimController : ControllerBase
    {
        private IPolicyClaimService _policyClaimService;
        public PolicyClaimController(IPolicyClaimService policyClaimService)
        {
            _policyClaimService = policyClaimService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var policyClaimDTO = new List<PolicyClaimDto>();
            var policyClaims = _policyClaimService.GetAll();
            if (policyClaims.Count > 0)
            {
                foreach (var policyClaim in policyClaims)
                {
                    policyClaimDTO.Add(ConvertToDTO(policyClaim));
                }
                return Ok(policyClaimDTO);
            }
            throw new EntityNotFoundError("PolicyClaim not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var policyClaim = _policyClaimService.Get(id);
            if (policyClaim == null)
            {
                throw new EntityNotFoundError("PolicyClaim not found");
            }
            return Ok(ConvertToDTO(policyClaim));
        }
        [HttpPost]
        public IActionResult Add(PolicyClaimDto policyClaimDto)
        {
            var policyClaim = ConvertToModel(policyClaimDto);
            var policyClaimId = _policyClaimService.Add(policyClaim);
            if (policyClaimId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(policyClaimId);
        }
        [HttpPut]
        public IActionResult Update(PolicyClaimDto policyClaimDto)
        {
            var policyClaimDTOToUpdate = _policyClaimService.Check(policyClaimDto.Id);
            if (policyClaimDTOToUpdate != null)
            {
                var updatedPolicyClaim = ConvertToModel(policyClaimDto);
                var modifiedPolicyClaim = _policyClaimService.Update(updatedPolicyClaim);
                return Ok(ConvertToDTO(modifiedPolicyClaim));
            }
            throw new EntityNotFoundError("No PolicyClaim found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var policyClaim = _policyClaimService.Get(id);
            if (policyClaim != null)
            {
                _policyClaimService.Delete(policyClaim);
                return Ok(id);
            }
            throw new EntityNotFoundError("No PolicyClaim found to delete");
        }
        private PolicyClaim ConvertToModel(PolicyClaimDto policyClaimDto)
        {
            return new PolicyClaim()
            {
                Id=policyClaimDto.Id,
                InsurancePlanId=policyClaimDto.InsurancePlanId,
                CustomerId=policyClaimDto.CustomerId,
                BankName=policyClaimDto.BankName,
                WithdrawalAmount=policyClaimDto.WithdrawalAmount,
                WithdrawalDate=policyClaimDto.WithdrawalDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                
                IsActive = true

            };
        }
        private PolicyClaimDto ConvertToDTO(PolicyClaim policyClaim)
        {
            return new PolicyClaimDto()
            {
                Id = policyClaim.Id,
                InsurancePlanId = policyClaim.InsurancePlanId,
                CustomerId = policyClaim.CustomerId,
                BankName = policyClaim.BankName,
                WithdrawalAmount = policyClaim.WithdrawalAmount,
                WithdrawalDate = DateOnly.FromDateTime(policyClaim.WithdrawalDate),

            };
        }
    }
}

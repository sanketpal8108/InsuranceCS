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
    public class PolicyPaymentController : ControllerBase
    {
        private IPolicyPaymentService _policypaymentService;
        public PolicyPaymentController(IPolicyPaymentService policypaymentService)
        {
            _policypaymentService = policypaymentService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var policypayDTO = new List<PolicyPaymentDto>();
            var policypays = _policypaymentService.GetAll();
            if (policypays.Count > 0)
            {
                foreach (var admin in policypays)
                {
                    policypayDTO.Add(ConvertToDTO(admin));
                }
                return Ok(policypayDTO);
            }
            throw new EntityNotFoundError("PolicyPayment not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var policypay = _policypaymentService.Get(id);
            if (policypay == null)
            {
                throw new EntityNotFoundError("PolicyPayment not found");
            }
            return Ok(ConvertToDTO(policypay));
        }
        [HttpPost]
        public IActionResult Add(PolicyPaymentDto policypayDto)
        {
            var policypay = ConvertToModel(policypayDto);
            var policypayId = _policypaymentService.Add(policypay);
            if (policypayId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(policypayId);
        }
        [HttpPut]
        public IActionResult Update(PolicyPaymentDto policypayDto)
        {
            var policypayDTOToUpdate = _policypaymentService.Check(policypayDto.Id);
            if (policypayDTOToUpdate != null)
            {
                var updatedpolicypay = ConvertToModel(policypayDto);
                var modifiedPolicypay = _policypaymentService.Update(updatedpolicypay);
                return Ok(ConvertToDTO(modifiedPolicypay));
            }
            throw new EntityNotFoundError("No PolicyPayment found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var policypay = _policypaymentService.Get(id);
            if (policypay != null)
            {
                _policypaymentService.Delete(policypay);
                return Ok(id);
            }
            throw new EntityNotFoundError("No PolicyPayment found to delete");
        }
        private PolicyPayment ConvertToModel(PolicyPaymentDto policypaymentDto)
        {
            return new PolicyPayment()
            {
                Id = policypaymentDto.Id,
                InsurancePlanId = policypaymentDto.InsurancePlanId,
                CustomerId = policypaymentDto.CustomerId,
                PaidAmount = policypaymentDto.PaidAmount,
                PaidDate = policypaymentDto.PaidDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                TaxAmount = policypaymentDto.TaxAmount,
                TotalAmount = policypaymentDto.TotalAmount,
                TransactionType = policypaymentDto.TransactionType,
                CustomerInsuranceAccountId = policypaymentDto.CustomerInsuranceAccountId,
                IsPaid = policypaymentDto.IsPaid,
                IsActive = true

            };
        }
        private PolicyPaymentDto ConvertToDTO(PolicyPayment policyPayment)
        {
            return new PolicyPaymentDto()
            {
                Id = policyPayment.Id,
                InsurancePlanId=policyPayment.InsurancePlanId,
                CustomerId = policyPayment.CustomerId,
                PaidAmount=policyPayment.PaidAmount,
                PaidDate= DateOnly.FromDateTime(policyPayment.PaidDate),
                TaxAmount=policyPayment.TaxAmount,
                TotalAmount=policyPayment.TotalAmount,
                TransactionType=policyPayment.TransactionType,  
                CustomerInsuranceAccountId=policyPayment.CustomerInsuranceAccountId,
                IsPaid=policyPayment.IsPaid,
            };
        }
    }
}

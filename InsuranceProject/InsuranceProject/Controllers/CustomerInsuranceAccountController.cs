﻿using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInsuranceAccountController : ControllerBase
    {
        private ICustomerInsuranceAccountService _customerInsuranceAccountService;
        
        public CustomerInsuranceAccountController(ICustomerInsuranceAccountService customerInuranceAccountService)
        {
            _customerInsuranceAccountService = customerInuranceAccountService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var customerInsuranceAccountDTO = new List<CustomerInsuranceAccountDto>();
            var customerInsuranceAccounts = _customerInsuranceAccountService.GetAll();
            if (customerInsuranceAccounts.Count > 0)
            {
                foreach (var customerInsuranceAccount in customerInsuranceAccounts)
                {
                    customerInsuranceAccountDTO.Add(ConvertToDTO(customerInsuranceAccount));
                }
                return Ok(customerInsuranceAccountDTO);
            }
            throw new EntityNotFoundError("CustomerInsuranceAccount not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var customerInsuranceAccount = _customerInsuranceAccountService.Get(id);
            if (customerInsuranceAccount == null)
            {
                throw new EntityNotFoundError("CustomerInsuranceAccount not found");
            }
            return Ok(ConvertToDTO(customerInsuranceAccount));
        }
        [HttpGet("ByCustomerId/{customerId:int}")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var customerInsuranceAccountDTO = new List<CustomerInsuranceAccountDto>();
            var customerInsuranceAccounts = _customerInsuranceAccountService.GetByCustomerId(customerId);
            if (customerInsuranceAccounts.Count > 0)
            {
                foreach (var customerInsuranceAccount in customerInsuranceAccounts)
                {
                    customerInsuranceAccountDTO.Add(ConvertToDTO(customerInsuranceAccount));
                }
                return Ok(customerInsuranceAccountDTO);
            }
            throw new EntityNotFoundError("CustomerInsuranceAccount not found");
        }
        [HttpPost]
        public IActionResult Add(CustomerInsuranceAccountDto customerInsuranceAccountDto)
        {
            var customerInsuranceAccount = ConvertToModel(customerInsuranceAccountDto);
            var customerInsuranceAccountId = _customerInsuranceAccountService.Add(customerInsuranceAccount);
            if (customerInsuranceAccountId == null)
                throw new EntityInsertError("Some errors Occurred");
            var newAcc = _customerInsuranceAccountService.FindByPlanId(customerInsuranceAccountDto.InsurancePlanId);
            return Ok(newAcc.Id);
        }
        [HttpPut]
        public IActionResult Update(CustomerInsuranceAccountDto customerInsuranceAccountDto)
        {
            var customerInsuranceAccountDTOToUpdate = _customerInsuranceAccountService.Check(customerInsuranceAccountDto.Id);
            if (customerInsuranceAccountDTOToUpdate != null)
            {
                var updatedCustomerInsuranceAccount = ConvertToModel(customerInsuranceAccountDto);
                var modifiedCustomerInsuranceAccount = _customerInsuranceAccountService.Update(updatedCustomerInsuranceAccount);
                return Ok(ConvertToDTO(modifiedCustomerInsuranceAccount));
            }
            throw new EntityNotFoundError("No CustomerInsuranceAccount found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var customerInsuranceAccount = _customerInsuranceAccountService.Get(id);
            if (customerInsuranceAccount != null)
            {
                _customerInsuranceAccountService.Delete(customerInsuranceAccount);
                return Ok(id);
            }
            throw new EntityNotFoundError("No CustomerInsuranceAccount found to delete");
        }
        private CustomerInsuranceAccount ConvertToModel(CustomerInsuranceAccountDto customerInsuranceAccountDto)
        {
            return new CustomerInsuranceAccount()
            {
                Id = customerInsuranceAccountDto.Id,
                CustomerId = customerInsuranceAccountDto.CustomerId,
                InsurancePlanId = customerInsuranceAccountDto.InsurancePlanId,
                PolicyTerm = customerInsuranceAccountDto.PolicyTerm,
                InsuranceCreationDate = customerInsuranceAccountDto.InsuranceCreationDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                MaturityDate = customerInsuranceAccountDto.MaturityDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                SumAssured = customerInsuranceAccountDto.SumAssured,
                ProfitRatio = customerInsuranceAccountDto.ProfitRatio,
                TotalPremium = customerInsuranceAccountDto.TotalPremium,

                IsActive = true

            };
        }
        private CustomerInsuranceAccountDto ConvertToDTO(CustomerInsuranceAccount customerInsuranceAccount)
        {
            return new CustomerInsuranceAccountDto()
            {
                Id = customerInsuranceAccount.Id,
                InsuranceCreationDate = DateOnly.FromDateTime(customerInsuranceAccount.InsuranceCreationDate),
                MaturityDate = DateOnly.FromDateTime(customerInsuranceAccount.MaturityDate),
                InsurancePlanId = customerInsuranceAccount.InsurancePlanId,
                PolicyTerm = customerInsuranceAccount.PolicyTerm,
                TotalPremium = customerInsuranceAccount.TotalPremium,
                SumAssured = customerInsuranceAccount.SumAssured,
                CustomerId = customerInsuranceAccount.CustomerId,
                ProfitRatio=customerInsuranceAccount.ProfitRatio,

            };
        }
    }
}

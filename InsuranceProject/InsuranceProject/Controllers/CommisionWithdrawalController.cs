using InsuranceDay1.Models;
using InsuranceProject.DTO;
using InsuranceProject.Exceptions;
using InsuranceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommisionWithdrawalController : ControllerBase
    {
        private  ICommisionWithdrawalService _commissionWithdrawalService;
        private ICommisionService _commissionService;
        public CommisionWithdrawalController(ICommisionWithdrawalService commissionWithdrawalService, ICommisionService commissionService)
        {
            _commissionWithdrawalService = commissionWithdrawalService;
            _commissionService = commissionService;

        }
        [HttpGet,Authorize(Roles = "Agent , Admin , Employee")]
        public IActionResult Get()
        {
            var commisionWithdrawalDto = new List<CommisionWithdrawalDto>();
            var commisionWithdrawals = _commissionWithdrawalService.GetAll();
            if (commisionWithdrawals.Count > 0)
            {
                foreach (var admin in commisionWithdrawals)
                {
                    commisionWithdrawalDto.Add(ConvertToDTO(admin));
                }
                return Ok(commisionWithdrawalDto);
            }
            throw new EntityNotFoundError("CommisionWithdrawal not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var commisionWithdrawal = _commissionWithdrawalService.Get(id);
            if (commisionWithdrawal == null)
            {
                throw new EntityNotFoundError("CommisionWithdrawal not found");
            }
            return Ok(ConvertToDTO(commisionWithdrawal));
        }
        [HttpPost]
        public IActionResult Add(CommisionWithdrawalDto commisionWithdrawalDto)
        {
            var commisionData = _commissionService.GetAll();
            var amount = commisionWithdrawalDto.WithdrawalAmount;
            if (commisionData != null)
            {
                foreach (var commision in commisionData)
                {
                    if (amount <= commision.CommisionAmount)
                        commision.CommisionAmount = commision.CommisionAmount - amount;
                    else
                    {
                        amount = amount-commision.CommisionAmount;
                        commision.CommisionAmount = commision.CommisionAmount-commision.CommisionAmount;
                    }
                    _commissionService.Update(commision);
                }
                var commisionWithdrawal = ConvertToModel(commisionWithdrawalDto);
                var CommisionWithdrawalId = _commissionWithdrawalService.Add(commisionWithdrawal);
                if (CommisionWithdrawalId == null)
                    throw new EntityInsertError("Some errors Occurred");
                return Ok(CommisionWithdrawalId);
            }
            return BadRequest("No commision found");
        }
        [HttpPut]
        public IActionResult Update(CommisionWithdrawalDto commisionWithdrawalDto)
        {
            var commisionWithdrawalDTOToUpdate = _commissionWithdrawalService.Check(commisionWithdrawalDto.Id);
            if (commisionWithdrawalDTOToUpdate != null)
            {
                var updatedcommisionWithdrawal = ConvertToModel(commisionWithdrawalDto);
                var modifiedcommisionWithdrawal = _commissionWithdrawalService.Update(updatedcommisionWithdrawal);
                return Ok(ConvertToDTO(modifiedcommisionWithdrawal));
            }
            throw new EntityNotFoundError("No CommisionWithdrawal found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var commisionWithdrawal = _commissionWithdrawalService.Get(id);
            if (commisionWithdrawal != null)
            {
                _commissionWithdrawalService.Delete(commisionWithdrawal);
                return Ok(id);
            }
            throw new EntityNotFoundError("No CommisionWithdrawal found to delete");
        }
        private CommisionWithdrawal ConvertToModel(CommisionWithdrawalDto CommisionwithdrawalDto)
        {
            return new CommisionWithdrawal()
            {
                Id = CommisionwithdrawalDto.Id,
                RequestDate = CommisionwithdrawalDto.RequestDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                WithdrawalAmount = CommisionwithdrawalDto.WithdrawalAmount,
                //TotalWithdrawalAmount = CommisionwithdrawalDto.TotalWithdrawalAmount,
                IsApproved = CommisionwithdrawalDto.IsApproved,
                AgentId = CommisionwithdrawalDto.AgentId,
                IsActive=true,
                

            };
        }
        private CommisionWithdrawalDto ConvertToDTO(CommisionWithdrawal commisionwithdrawal)
        {
            return new CommisionWithdrawalDto()
            {
                Id = commisionwithdrawal.Id,
               RequestDate= DateOnly.FromDateTime(commisionwithdrawal.RequestDate),
               WithdrawalAmount= commisionwithdrawal.WithdrawalAmount,
               //TotalWithdrawalAmount=commisionwithdrawal.TotalWithdrawalAmount,
               AgentId= commisionwithdrawal.AgentId,
               IsApproved= commisionwithdrawal.IsApproved,
            };
        }
    }
}

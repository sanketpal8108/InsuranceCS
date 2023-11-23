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
        public CommisionWithdrawalController(ICommisionWithdrawalService commissionWithdrawalService)
        {
            _commissionWithdrawalService = commissionWithdrawalService;
        }
        [HttpGet,Authorize(Roles = "Agent")]
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
            var commisionWithdrawal = ConvertToModel(commisionWithdrawalDto);
            var CommisionWithdrawalId = _commissionWithdrawalService.Add(commisionWithdrawal);
            if (CommisionWithdrawalId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(CommisionWithdrawalId);
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
                RequestDate = CommisionwithdrawalDto.RequestDate,
                WithdrawalAmount = CommisionwithdrawalDto.WithdrawalAmount,
                TotalWithdrawalAmount = CommisionwithdrawalDto.TotalWithdrawalAmount,
                IsApproved = CommisionwithdrawalDto.IsApproved,
                IsActive=true,

            };
        }
        private CommisionWithdrawalDto ConvertToDTO(CommisionWithdrawal commisionwithdrawal)
        {
            return new CommisionWithdrawalDto()
            {
                Id = commisionwithdrawal.Id,
               RequestDate= commisionwithdrawal.RequestDate,
               WithdrawalAmount= commisionwithdrawal.WithdrawalAmount,
               TotalWithdrawalAmount=commisionwithdrawal.TotalWithdrawalAmount,
               IsApproved= commisionwithdrawal.IsApproved,
            };
        }
    }
}

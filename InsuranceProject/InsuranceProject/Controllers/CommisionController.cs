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
    public class CommisionController : ControllerBase
    {
        private ICommisionService _commisionService;
        public CommisionController(ICommisionService commisionService)
        {
            _commisionService = commisionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var commisionDTO = new List<CommisionDto>();
            var commisions = _commisionService.GetAll();
            if (commisions.Count > 0)
            {
                foreach (var commision in commisions)
                {
                    commisionDTO.Add(ConvertToDTO(commision));
                }
                return Ok(commisionDTO);
            }
            throw new EntityNotFoundError("Commision not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var commision = _commisionService.Get(id);
            if (commision == null)
            {
                throw new EntityNotFoundError("Commision not found");
            }
            return Ok(ConvertToDTO(commision));
        }
        [HttpPost]
        public IActionResult Add(CommisionDto commisionDto)
        {
            var commision = ConvertToModel(commisionDto);
            var commisionId = _commisionService.Add(commision);
            if (commisionId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(commisionId);
        }
        [HttpPut]
        public IActionResult Update(CommisionDto commisionDto)
        {
            var commisionDTOToUpdate = _commisionService.Check(commisionDto.Id);
            if (commisionDTOToUpdate != null)
            {
                var updatedCommision = ConvertToModel(commisionDto);
                var modifiedCommision = _commisionService.Update(updatedCommision);
                return Ok(ConvertToDTO(modifiedCommision));
            }
            throw new EntityNotFoundError("No Commision found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var commision = _commisionService.Get(id);
            if (commision != null)
            {
                _commisionService.Delete(commision);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Commision found to delete");
        }
        private Commision ConvertToModel(CommisionDto commisionDto)
        {
            return new Commision()
            {
                Id = commisionDto.Id,
                AgentId = commisionDto.AgentId,
                InsurancePlanId = commisionDto.InsurancePlanId,
                CustomerId = commisionDto.CustomerId,
                CommisionAmount = commisionDto.CommisionAmount,

                IsActive = true

            };
        }
        private CommisionDto ConvertToDTO(Commision commision)
        {
            return new CommisionDto()
            {
                Id= commision.Id,
                InsurancePlanId= commision.InsurancePlanId,
                AgentId = commision.AgentId,
                CustomerId = commision.CustomerId,
                CommisionAmount = commision.CommisionAmount,

            };
        }
    }
}

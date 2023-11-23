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
    public class LocationController : ControllerBase
    {
        private ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var locationDTO = new List<LocationDto>();
            var locations = _locationService.GetAll();
            if (locations.Count > 0)
            {
                foreach (var location in locations)
                {
                    locationDTO.Add(ConvertToDTO(location));
                }
                return Ok(locationDTO);
            }
            throw new EntityNotFoundError("Location not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var location = _locationService.Get(id);
            if (location == null)
            {
                throw new EntityNotFoundError("Location not found");
            }
            return Ok(ConvertToDTO(location));
        }
        [HttpPost]
        public IActionResult Add(LocationDto locationDto)
        {
            var location = ConvertToModel(locationDto);
            var locationId = _locationService.Add(location);
            if (locationId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(locationId);
        }
        [HttpPut]
        public IActionResult Update(LocationDto locationDto)
        {
            var locationDTOToUpdate = _locationService.Check(locationDto.Id);
            if (locationDTOToUpdate != null)
            {
                var updatedLocation = ConvertToModel(locationDto);
                var modifiedLocation = _locationService.Update(updatedLocation);
                return Ok(ConvertToDTO(modifiedLocation));
            }
            throw new EntityNotFoundError("No Location found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var location = _locationService.Get(id);
            if (location != null)
            {
                _locationService.Delete(location);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Location found to delete");
        }
        private Location ConvertToModel(LocationDto locationDto)
        {
            return new Location()
            {
                Id = locationDto.Id,
                State = locationDto.State,
                City = locationDto.City,

                IsActive = true

            };
        }
        private LocationDto ConvertToDTO(Location location)
        {
            return new LocationDto()
            {
                Id = location.Id,
                State = location.State,
                City = location.City,
                CountCustomer = location.City != null ? location.City.Count() : 0

            };
        }
    }
}

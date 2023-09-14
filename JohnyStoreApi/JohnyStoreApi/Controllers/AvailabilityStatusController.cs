using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AvailabilityStatusController : ControllerBase
    {
        private readonly IAvailabilityDataStatusService _availabilityDataStatusService;

        public AvailabilityStatusController(IAvailabilityDataStatusService availabilityDataStatusService)
        {
            _availabilityDataStatusService = availabilityDataStatusService;
        }

        /// <summary>
        /// Получение всех статусов наличия
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAvailabilityStatuses")]
        public List<AvailabilityStatusModel> GetAvailabilityStatuses()
        {
            return _availabilityDataStatusService.GetAvailabilityStatuses();
        }

        /// <summary>
        /// Добавление статуса наличия
        /// </summary>
        /// <param name="availabilityStatus"></param>
        /// <returns></returns>
        [HttpPost("AddAvailabilityStatus")]
        public IActionResult AddAvailabilityStatus([FromBody] AvailabilityStatusModel availabilityStatus)
        {
            bool check = _availabilityDataStatusService.AddAvailabilityStatus(availabilityStatus);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Удаление статуса о наличии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAvailabilityStatus/{id}")]
        public IActionResult DeleteAvailabilityStatus(int id)
        {
            bool check = _availabilityDataStatusService.DeleteAvailabilityStatus(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

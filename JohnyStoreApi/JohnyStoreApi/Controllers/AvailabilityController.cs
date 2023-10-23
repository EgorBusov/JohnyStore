using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Services;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityDataService _availabilityDataService;
        public AvailabilityController(IAvailabilityDataService availabilityDataService)
        {
            _availabilityDataService = availabilityDataService;
        }

        /// <summary>
        /// Получение информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="idSneaker"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAvailability/{id}")]
        public AvailabilityModel GetAvailability(int idSneaker)
        {
            return _availabilityDataService.GetAvailability(idSneaker);
        }

        /// <summary>
        /// Добавление информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("AddAvailability")]
        public IActionResult AddAvailability([FromForm] AddAvailabilityModel model)
        {
            bool check = _availabilityDataService.AddAvailability(model);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Редактирование информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("EditAvailability")]
        public IActionResult EditAvailability([FromForm] AddAvailabilityModel model)
        {
            bool check = _availabilityDataService.EditAvailability(model);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Удаление информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteAvailability/{sneakerId}")]
        public IActionResult DeleteAvailability(int sneakerId)
        {
            bool check = _availabilityDataService.DeleteAvailability(sneakerId);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

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
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAvailability/{id}")]
        public AvailabilityModel GetAvailability(int id)
        {
            return _availabilityDataService.GetAvailability(id);
        }

        /// <summary>
        /// Добавление информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("AddAvailability")]
        public IActionResult AddAvailability([FromBody] AvailabilityModel model)
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
        public IActionResult EditAvailability([FromBody] AvailabilityModel model)
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
        [HttpDelete("DeleteAvailability/{id}")]
        public IActionResult DeleteAvailability(int id)
        {
            bool check = _availabilityDataService.DeleteAvailability(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

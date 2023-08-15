using JohnyStoreApi.Models.Availability;
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
        [Route("Get/{id}")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public AvailabilityModel GetAvailability(int id)
        {
            return _availabilityDataService.GetAvailability(id);
        }

        /// <summary>
        /// Добавление информации о наличии определенной модели кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Add")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddAvailability([FromForm] AvailabilityModel model)
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
        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult EditAvailability([FromForm] AvailabilityModel model)
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
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAvailability(int id)
        {
            bool check = _availabilityDataService.DeleteAvailability(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

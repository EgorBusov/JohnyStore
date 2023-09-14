using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusDataService _orderStatusDataService;

        public OrderStatusController(IOrderStatusDataService orderStatusDataService)
        {
            _orderStatusDataService = orderStatusDataService;
        }

        [HttpGet("GetOrderStatuses")]
        public List<OrderStatusModel> GetOrderStatuses()
        {
            return _orderStatusDataService.GetOrderStatuses();
        }

        /// <summary>
        /// Добавление нового статуса
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        [HttpPost("AddStatus")]
        public IActionResult AddStatus([FromBody] OrderStatusModel orderStatus)
        {
            bool check = _orderStatusDataService.AddStatus(orderStatus);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Удаление статуса
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteStatus/{id}")]
        public IActionResult DeleteStatus(int id)
        {
            bool check = _orderStatusDataService.DeleteStatus(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

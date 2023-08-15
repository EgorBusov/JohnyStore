using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class OrderStatusController : Controller
    {
        private readonly IOrderStatusDataService _orderStatusDataService;

        public OrderStatusController(IOrderStatusDataService orderStatusDataService)
        {
            _orderStatusDataService = orderStatusDataService;
        }

        [Route("GetStatuses")]
        [HttpGet]
        public List<OrderStatusModel> GetOrderStatuses()
        {
            return _orderStatusDataService.GetOrderStatuses();
        }

        /// <summary>
        /// Добавление нового статуса
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public IActionResult AddStatus([FromForm] OrderStatusModel orderStatus)
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
        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            bool check = _orderStatusDataService.DeleteStatus(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

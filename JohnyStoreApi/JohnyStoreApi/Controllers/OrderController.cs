using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDataService _orderDataService;

        public OrderController(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
        }

        /// <summary>
        /// Получение заказа по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetOrderById/{id}")]
        public OrderModel GetOrderById(int id)
        {
            return _orderDataService.GetOrderById(id);
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("GetOrders")]
        public List<OrderModel> GetOrders()
        {
            return _orderDataService.GetOrders();
        }

        /// <summary>
        /// перевод заказа в следующий статус
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("NextStatusOrder/{id}")]
        public IActionResult NextStatusOrder(int id)
        {
            bool check = _orderDataService.NextStatusOrder(id);

            if(check)
                return Ok();

            return BadRequest();

        }

        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromForm] AddOrderModel model)
        {
            bool check = _orderDataService.AddOrder(model);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            bool check = _orderDataService.DeleteOrder(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

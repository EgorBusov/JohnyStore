using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
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
        [Route("GetOrderById/{id}")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public OrderModel GetOrderById(int id)
        {
            return _orderDataService.GetOrderById(id);
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        [Route("GetOrders")]
        [AllowAnonymous]
        [HttpGet]
        public List<OrderModel> GetOrders()
        {
            return _orderDataService.GetOrders();
        }

        /// <summary>
        /// перевод заказа в следующий статус
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("Admin")]
        [Route("NextStatus")]
        [HttpGet("{id}")]
        public IActionResult NextStatusOrder(int id)
        {
            bool check = _orderDataService.NextStatusOrder(id);

            if(check)
                return Ok();

            return BadRequest();

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Add")]
        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AddOrder([FromForm] OrderModel model)
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
        [Authorize("Admin")]
        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            bool check = _orderDataService.DeleteOrder(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}

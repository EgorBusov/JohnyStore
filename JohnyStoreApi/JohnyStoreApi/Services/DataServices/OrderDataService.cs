using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Services.AdditionalServices;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using System.Collections.Concurrent;

namespace JohnyStoreApi.Services.DataServices
{
    public class OrderDataService : IOrderDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IConfiguration _configuration;

        public OrderDataService(JohnyStoreContext context, IJohnyStoreLogger logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Получение заказа по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderModel GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id && x.Visible != false)?.MapToOrderModel(_context, _configuration) 
                ?? new OrderModel();
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        public List<OrderModel> GetOrders()
        {
            return _context.Orders.Where(x => x.Visible != false).ToList().MapToOrderModels(_context, _configuration)
                ?? new List<OrderModel>();
        }

        /// <summary>
        /// Перевод статуса заказа на следующий
        /// </summary>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public bool NextStatusOrder(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(x => x.Id == id) ?? throw new Exception("Заказ не найдет");
                order.Status = _context.OrderStatuses.FirstOrDefault(x => x.Id == GetNextIdStatus(order.Status.Id)) 
                    ?? throw new Exception("Статус не найдет");

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }            
        }

        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrder(AddOrderModel model)
        {
            try
            {
                if (!model.Validate(_context))
                    throw new Exception("При добавлении заказа, данные не валидны");

                model.Status = _context.OrderStatuses
                .Where(x => x.Visible == true)
                .OrderBy(x => x.Position)
                .First().Id;

                Order order = model.MapToOrder(_context);

                _context.Orders.Add(order);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="idOrder"></param>
        /// <returns></returns>
        public bool DeleteOrder(int idOrder)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(x => x.Id == idOrder) ?? throw new Exception("Заказ не найден");
                order.Visible = false;
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Получение следующего статуса
        /// </summary>
        /// <param name="idStatus"></param>
        /// <returns></returns>
        private int GetNextIdStatus(int idStatus)
        {
            var orderStatuses = _context.OrderStatuses
                .Where(x => x.Visible == true)
                .OrderBy(x => x.Position)
                .ToList();

            int indexNewStatus = orderStatuses.FindIndex(x => x.Id == idStatus) + 1;
            if (indexNewStatus < orderStatuses.Count && indexNewStatus != 0)
            {
                return orderStatuses[indexNewStatus].Id;
            }
            else
            {
                return idStatus;
            }
        }

        #region OrderStatus CRD

        /// <summary>
        /// Получение всех статусов
        /// </summary>
        /// <returns></returns>
        public List<OrderStatusModel> GetOrderStatuses()
        {
            return _context.OrderStatuses
                .Where(x => x.Visible == true)
                .OrderBy(x => x.Position)
                .ToList()
                .MapToOrderStatusModels()
                ?? new List<OrderStatusModel>();
        }

        /// <summary>
        /// Добавление статуса
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddStatus(OrderStatusModel model)
        {
            try
            {
                if(!(model.Validate(_context)))
                    throw new Exception("При добавлении статуса, данные не валидны");

                OrderStatus status = model.MapToOrderStatus();
                _context.OrderStatuses.Add(status);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Удаление статуса
        /// </summary>
        /// <param name="idStatus"></param>
        /// <returns></returns>
        public bool DeleteStatus(int idStatus)
        {
            try
            {
                var status = _context.OrderStatuses.FirstOrDefault(x => x.Id == idStatus && x.Visible == true) 
                    ?? throw new Exception("Статус не найден");
                status.Visible = false;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        #endregion
    }
}

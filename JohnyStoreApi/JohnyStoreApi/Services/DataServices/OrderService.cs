using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using System.Collections.Concurrent;

namespace JohnyStoreApi.Services.DataServices
{
    public class OrderService : IOrderDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IConfiguration _configuration;

        public OrderService(JohnyStoreContext context, IJohnyStoreLogger logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }


    }
}

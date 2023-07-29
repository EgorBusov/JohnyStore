using JohnyStoreApi.Data.Models;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreData.EF;

namespace JohnyStoreApi.Logging
{
    public class JohnyStoreLogger : IJohnyStoreLogger
    {
        private readonly JohnyStoreContext _context;
        public JohnyStoreLogger(JohnyStoreContext context)
        {
            _context = context;
        }

        public void ErrorLog(string exceptionMessage)
        {
            Log log = new Log()
            {
                Name = "Error",
                Description = exceptionMessage,
                CreatedDate = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        public void InfoLog(string message)
        {
            Log log = new Log()
            {
                Name = "Info",
                Description = message,
                CreatedDate = DateTime.Now
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}

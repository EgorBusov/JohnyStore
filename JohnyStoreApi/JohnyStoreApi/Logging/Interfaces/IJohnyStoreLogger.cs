namespace JohnyStoreApi.Logging.Interfaces
{
    public interface IJohnyStoreLogger
    {
        void InfoLog(string message);
        void ErrorLog(string exceptionMessage);
    }
}

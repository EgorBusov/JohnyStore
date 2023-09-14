namespace JohnyStoreApi.Services.Interfaces
{
    public interface IMailSender
    {
        void SendMail(string email, string themeMail, string message);
    }
}

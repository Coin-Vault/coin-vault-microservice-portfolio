namespace PortfolioService.AsyncDataServices
{
    public interface IMessageBusEncryption
    {
        string DecryptString(string key, string message);
    }
}

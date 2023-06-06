namespace PortfolioService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
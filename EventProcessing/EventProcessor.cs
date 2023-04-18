using AutoMapper;
using PortfolioService.Data;
using PortfolioService.Dtos;
using PortfolioService.Models;
using System.Text.Json;

namespace PortfolioService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopedFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopedFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch(eventType)
            {
                case EventType.TradePublish:
                    addTrade(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("Determining event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(eventType.Event)
            {
                case "Trade_Publish":
                    Console.WriteLine($"Trade publish event: {eventType.Event}");
                    return EventType.TradePublish;
                default:
                    Console.WriteLine("Could not determine event type");
                    return EventType.Undetermined;
            }
        }

        private void addTrade(string tradePublishMessage)
        {
            using (var scope = _scopedFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IPortfolioRepo>();

                var tradePublishDto = JsonSerializer.Deserialize<TradePublishDto>(tradePublishMessage);

                try
                {
                    var portfolio = _mapper.Map<Portfolio>(tradePublishDto);

                    repo.CreatePortfolio(portfolio);
                    repo.SaveChanges();

                    Console.WriteLine($"Added trade to DB");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Could not add trade to DB: {exception.Message}");
                }
            }
        }
    }

    enum EventType
    {
        TradePublish,
        Undetermined
    }
}
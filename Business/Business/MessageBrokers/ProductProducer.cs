using Business.Producer;
using MassTransit;

namespace Business.MessageBrokers
{
    public class ProductProducer
    {
        private readonly IBus _bus;

        public ProductProducer(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendProductCreatedEvent(ProductCreatedEvent productEvent)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/product-queue"));
            await endpoint.Send(productEvent);
        }
    }
}

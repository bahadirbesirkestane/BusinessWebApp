using Business.Models;
using MassTransit;

namespace Business.Consumers
{
    public class MessageConsumer : IConsumer<MessageModel>
    {
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<MessageModel> context)
        {
            var message = context.Message;
            _logger.LogInformation($"[Consumer] Mesaj alındı: {message.Text} - {message.CreatedAt}");

            await Task.CompletedTask;
        }
    }
}

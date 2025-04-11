using Business.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class MesajController : Controller
    {
        private readonly IBus _bus;

        public MesajController(IBus bus)
        {
            _bus = bus;
        }
        public async Task<IActionResult> SendMessage()
        {
            var message = new MessageModel
            {
                Text = "Merhaba, RabbitMQ!",
                CreatedAt = DateTime.Now
            };

            await _bus.Publish(message);

            return Content("Mesaj gönderildi!");
        }
    }
}

using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.ValidationRules;
using Business.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IProductService _productService;

        public MessageController(IMessageService messageService, IProductService productService)
        {
            _messageService = messageService;
            _productService = productService;
        }

        public IActionResult MessageList()
        {
            var messages = _messageService.GetList();

            return View(messages);
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            var productList = _productService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductId.ToString()
                }).ToList();

            ViewBag.Products = productList;

            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            MessageValidator valRules = new MessageValidator();

            ValidationResult results = valRules.Validate(message);

            if (results.IsValid)
            {
                _messageService.AddT(message);
                return RedirectToAction("Index","Home"); // Başarılı sayfasına yönlendirme
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            var productList = _productService.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductId.ToString()
                }).ToList();

            ViewBag.Products = productList;

            return View(message);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = _messageService.TGetById(id);


            if (message == null)
                return NotFound();

            Product product = null;

            if (message.ProductId.HasValue)
            {
                product = _productService.TGetById(message.ProductId.Value);

                message.Product = product;
            }

            return View(message);
        }

        [HttpPost]
        public IActionResult ReplyMessage(int id, string replyText)
        {
            var message = _messageService.TGetById(id);
            if (message == null)
            {
                TempData["Error"] = "Mesaj bulunamadı.";
                return RedirectToAction("MessageList");
            }

            if (string.IsNullOrWhiteSpace(replyText))
            {
                TempData["Error"] = "Admin mesajı boş olamaz.";
                return RedirectToAction("MessageDetail", new { id });
            }

            message.AdminReply = replyText;
            message.MessageIsAnswered = true;
            _messageService.UpdateT(message);
            TempData["Success"] = "Mesaj başarıyla cevaplandı.";

            return RedirectToAction("MessageList");
        }
    }
}

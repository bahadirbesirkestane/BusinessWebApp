using Business.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Admin
{
    public class AdminMessageNotification : ViewComponent
    {
        private readonly IAdminService _adminService;
        private readonly IMessageService _messageService;

        public AdminMessageNotification(IAdminService adminService, IMessageService messageService)
        {
            _adminService = adminService;
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _messageService.GetList();

            return View(values);
        }
    }
}

using Business.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMessageService _messageService;

        public AdminController(IAdminService adminService,IMessageService messageService)
        {
            _adminService=adminService;
            _messageService = messageService;
        }

        public IActionResult Index()
        { 
            return View();
        }
    }
}

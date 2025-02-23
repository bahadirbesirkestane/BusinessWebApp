using Business.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        { 
            return View();
        }
    }
}

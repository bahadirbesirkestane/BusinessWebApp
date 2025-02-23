using Business.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Admin
{
    public class AdminNotification : ViewComponent
    {
        private readonly IAdminService _adminService;

        public AdminNotification(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

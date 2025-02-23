using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Business.ViewComponents.Admin
{
    public class AdminMessageNotification : ViewComponent
    {
        private readonly IAdminService _adminService;

        public AdminMessageNotification(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

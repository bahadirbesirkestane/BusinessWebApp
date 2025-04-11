using Business.BusinessLayer.Abstract;
using Business.BusinessLayer.ValidationRules;
using Business.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        public IActionResult PageList()
        {
            var pages = _pageService.GetList();

            return View(pages);
        }

        [HttpGet]
        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPage(Page page)
        {
            PageValidator validationRules = new PageValidator();

            ValidationResult results = validationRules.Validate(page);

            if (results.IsValid)
            {
                page.PageStatus = true;

                _pageService.AddT(page);

                return RedirectToAction("PageList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditPage(int id)
        {
            var pageValue = _pageService.TGetById(id);

            return View(pageValue);
        }

        [HttpPost]
        public IActionResult EditPage(Page page)
        {
            PageValidator validationRules = new PageValidator();

            ValidationResult results = validationRules.Validate(page);

            var pageValue = _pageService.TGetById(page.PageId);

            if (results.IsValid)
            {
                pageValue.PageTitle = page.PageTitle;
                pageValue.PageContent = page.PageContent;
                pageValue.PageType = page.PageType;
                pageValue.PageStatus = page.PageStatus;

                _pageService.UpdateT(pageValue);

                return RedirectToAction("PageList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(pageValue);
        }

        public IActionResult DeletePage(int id)
        {
            var pageValue = _pageService.TGetById(id);

            _pageService.RemoveT(pageValue);

            return RedirectToAction("PageList");
        }

        public IActionResult AboutPage()
        {
            var page = _pageService.GetPageByName("About");

            return View(page);
        }
    }
}

using Business.BusinessLayer.Abstract;
using Business.DataAccess.Abstact;
using Business.Models.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Business.BusinessLayer.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(IGenericRepository<Category> repository,ICategoryDAL categoryDAL) : base(repository)
        {
            _categoryDAL = categoryDAL;
        }

        public List<SelectListItem> GetCategorySelectList()
        {
            var values= GetList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return values;

            //return base.GetList().Select(x => new SelectListItem
            //{
            //    Text = x.CategoryName,
            //    Value = x.CategoryId.ToString()
            //}).ToList();
        }
    }
}

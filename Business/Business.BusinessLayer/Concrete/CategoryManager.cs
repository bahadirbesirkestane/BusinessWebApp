using Business.BusinessLayer.Abstract;
using Business.DataAccessLayer.Abstact;
using Business.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(IGenericDAL<Category> repository,ICategoryDAL categoryDAL) : base(repository)
        {
            _categoryDAL = categoryDAL;
        }

        public List<SelectListItem> GetCategorySelectList()
        {
            var values = GetList().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return values;
        }
    }
}

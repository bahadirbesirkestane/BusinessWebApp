using Business.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<SelectListItem> GetCategorySelectList();
    }
}

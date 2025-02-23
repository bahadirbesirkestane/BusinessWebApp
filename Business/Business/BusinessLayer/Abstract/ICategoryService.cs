using Business.Models.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<SelectListItem> GetCategorySelectList();
    }
}

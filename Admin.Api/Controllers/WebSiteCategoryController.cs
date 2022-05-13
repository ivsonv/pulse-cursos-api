using Microsoft.AspNetCore.Mvc;
using Admin.Domain.Interface.Services;

namespace Admin.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "website")]
    [Route("website/category")]
    public class WebSiteCategoryController : RestFullServiceBaseController<Domain.Entities.WebSiteCategory>
    {
        public WebSiteCategoryController(IBaseService<Domain.Entities.WebSiteCategory> baseService) : base(baseService)
        { }

        //[HttpGet("types")]
        //public dynamic AllTypes()
        //    => _categoryService.AllTypes();
    }
}
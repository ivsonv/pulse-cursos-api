using Admin.Domain.Interface.Entities;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;
using Admin.Domain.Models.Response.WebSite;
using Admin.Domain.Helpers;

namespace Admin.Application.Services
{
    public class WebSiteCategoryService
    {
        private readonly IWebSiteCategoryRepository _categoryRepository;

        public WebSiteCategoryService(IWebSiteCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseRs<List<CategoryRs>>> Show(BaseRq<Domain.Entities.WebSiteCategory> _request)
        {
            var _res = new BaseRs<List<CategoryRs>>();
            try
            {
                _res.Content = await _categoryRepository.Show(_request.Search, _request.Pagination);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteCategory>> Create(BaseRq<Domain.Entities.WebSiteCategory> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteCategory>();
            try
            {
                await _categoryRepository.Create(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteCategory>> Update(BaseRq<Domain.Entities.WebSiteCategory> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteCategory>();
            try
            {
                if (_req.Data.parent_id <= 0)
                    _req.Data.parent_id = null;


                await _categoryRepository.Update(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<CategoryRs>> FindById(long id)
        {
            var _res = new BaseRs<CategoryRs>();
            try
            {
                var entity = await _categoryRepository.FindById(id);
                if (entity != null)
                {
                    _res.Content = new CategoryRs()
                    {
                        description_short = entity.description_short,
                        description_long = entity.description_long,
                        SubCategories = entity.SubCategories,
                        category_type = entity.category_type,
                        parent_id = entity.parent_id,
                        active = entity.active,
                        Parent = entity.Parent,
                        image = entity.image,
                        name = entity.name,
                        id = entity.id
                    };
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                await _categoryRepository.Delete(await _categoryRepository.FindById(id));
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public BaseRs<IEnumerable<Domain.Models.DTO.EnumValue>> AllTypes()
        {
            return new BaseRs<IEnumerable<Domain.Models.DTO.EnumValue>>()
            {
                Content = CustomExtensions.GetValues<Enumerados.CategoryType>()
            };
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Admin.Domain.Interface.Services;
using Admin.Domain.Models.Response;
using Admin.Domain.Models.Request;
using Admin.Domain.Helpers;

namespace Admin.Api.Controllers
{
    public class RestFullServiceBaseController<T>
    {
        private readonly IBaseService<T> _baseService;

        public RestFullServiceBaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet, AdminAuthorizeCustom] // permission dynamic individual, se não informada gera automatica dentro do middlaware
        public async virtual Task<BaseRs> Index([FromQuery] BaseRq<T> Req)
            => await _baseService.Index(Req);

        [HttpPost, AdminAuthorizeCustom]
        public async virtual Task<BaseRs> Store([FromBody] BaseRq<T> Req)
            => await _baseService.Store(Req);

        [HttpPut, AdminAuthorizeCustom]
        public async virtual Task<BaseRs> Update([FromBody] BaseRq<T> Req)
            => await _baseService.Update(Req);

        [HttpGet, Route("{id:int}"), AdminAuthorizeCustom]
        public async virtual Task<BaseRs> FindById([FromRoute] int id)
            => await _baseService.FindById(id);

        [HttpDelete, Route("{id:int}"), AdminAuthorizeCustom]
        public async virtual Task<BaseRs> Delete([FromRoute] int id)
            => await _baseService.Delete(id);
    }
}
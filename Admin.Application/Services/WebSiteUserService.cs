using Admin.Domain.Helpers;
using Admin.Domain.Interface.Entities;
using Admin.Domain.Models.Request;
using Admin.Domain.Models.Response;
using Microsoft.Extensions.Configuration;

namespace Admin.Application.Services
{
    public class WebSiteUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebSiteUserRepository _repository;

        public WebSiteUserService(
            IConfiguration configuration,
            IWebSiteUserRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<BaseRs<Domain.Models.DTO.Auth.AuthRs>> Login(Domain.Models.Request.User.AuthRq _req)
        {
            var _res = new BaseRs<Domain.Models.DTO.Auth.AuthRs>();
            try
            {
                if (!_req.email.IsEmail()) _res.SetError("E-mail informado não e válido.");
                if (_req.password.IsEmpty()) _res.SetError("Informe uma senha.");

                var user = await _repository.FindByLogin(_req.email);

                if (user == null) _res.SetError("login/senha não conferem.");
                else if (user.password != _req.password.createHash()) _res.SetError("login/senha não conferem.");
                else if (user.GroupPermissions.IsEmpty()) _res.SetError("usuário sem grupo de permissão.");

                if (_res.Error == null)
                {
                    // obj
                    var dto = new Domain.Models.DTO.Auth.AuthDto()
                    {
                        permissions = user.GroupPermissions.Select(s => s.group_permission_id).Distinct(),
                        UserType = Enumerados.AuthUserType.admin,
                        Name = user.name,
                        Id = user.id
                    };

                    // permissões do usuário
                    var permissions = user.GroupPermissions
                        .SelectMany(ss => ss.GroupPermission.PermissionsAttached)
                        .Select(s => s.name)
                        .Distinct().ToList();

                    // retorno
                    _res.Content = new Domain.Models.DTO.Auth.AuthRs()
                    {
                        AccessToken = CustomExtensions.GenerateToken(dto, _configuration["secrets:signingkey"]),
                        Data = new Domain.Models.DTO.Auth.AuthData()
                        {
                            Rules = permissions,
                            FullName = dto.Name,
                            Id = dto.Id,
                        }
                    };
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<List<Domain.Entities.WebSiteUser>>> Show(BaseRq<string> _request)
        {
            var _res = new BaseRs<List<Domain.Entities.WebSiteUser>>();
            try
            {
                _res.Content = await _repository.Show(_request.Pagination, _request.Search);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteUser>> FindById(long id)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteUser>();
            try
            {
                _res.Content = await _repository.FindById(id);
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteUser>> Create(BaseRq<Domain.Entities.WebSiteUser> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteUser>();
            try
            {
                _req.Data.email = _req.Data.email.ToLower().Trim();
                _req.Data.name = _req.Data.name.ToUpper().Trim();

                #region ..: validations :..

                if (!_req.Data.email.IsEmail())
                    _res.SetError("E-mail informado não e válido.");

                if (_req.Data.password.IsEmpty())
                    _req.Data.password = "123456";

                var user = await _repository.FindByEmail(_req.Data.email);
                if (user != null)
                    _res.SetError("e-mail informado já esta em uso.");
                #endregion

                if (_res.Error == null)
                {
                    _req.Data.password = _req.Data.password.createHash();
                    await _repository.Create(_req.Data);

                    //_email.Send(new Domain.Models.DTO.EmailDto()
                    //{
                    //    Display = "Bem-vindo ao Sistema",
                    //    Title = "Usuário Criado",
                    //    Email = _req.Data.email,
                    //    Body = ""
                    //});
                    _res.Content = _req.Data;
                }
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<Domain.Entities.WebSiteUser>> Update(BaseRq<Domain.Entities.WebSiteUser> _req)
        {
            var _res = new BaseRs<Domain.Entities.WebSiteUser>();
            try
            {
                await _repository.Update(_req.Data);
                _res.Content = _req.Data;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
        public async Task<BaseRs<bool>> Delete(int id)
        {
            var _res = new BaseRs<bool>();
            try
            {
                await _repository.Delete(await _repository.FindById(id));
                _res.Content = true;
            }
            catch (Exception ex) { _res.SetError(ex); }
            return _res;
        }
    }
}
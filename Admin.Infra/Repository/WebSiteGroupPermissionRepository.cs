using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Admin.Domain.Interface.Cache;
using Admin.Domain.Helpers;

namespace Admin.Infra.Repository
{
    public class WebSiteGroupPermissionRepository : IWebSiteGroupPermissionRepository
    {
        private readonly BaseRepository<WebSiteGroupPermissionAttached> _repositoryAttached;
        private readonly BaseRepository<WebSiteGroupPermission> _repository;
        private readonly ICache _cache;

        public WebSiteGroupPermissionRepository(
            BaseRepository<WebSiteGroupPermissionAttached> repositoryAttached,
            BaseRepository<WebSiteGroupPermission> repository,
            ICache cache)
        {
            _repositoryAttached = repositoryAttached;
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<WebSiteGroupPermission>> Show(Pagination pagination)
        {
            return await _repository.Get(order: o => o.id, pagination)
                                    .Select(s => new WebSiteGroupPermission()
                                    {
                                        name = s.name,
                                        id = s.id,
                                    }).ToListAsync();
        }
        public async Task Create(WebSiteGroupPermission entity)
        {
            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteGroupPermission entity)
        {
            var _current = await this.FindById(entity.id);
            if (_current != null)
            {
                _current.name = entity.name;

                #region ..: permissions :..

                var permissionReceives = entity.PermissionsAttached.Select(s => s.name).ToList();
                var permissionCurrents = _current.PermissionsAttached.Select(s => s.name).ToList();
                var permissionRemoves = permissionCurrents.Where(w => !permissionReceives.Contains(w)).ToList();
                if (permissionRemoves.Any())
                {
                    var _lst = _current.PermissionsAttached.Where(w => permissionRemoves.Contains(w.name)).ToList();
                    _repositoryAttached.RemoveRange(_lst);
                    await _repositoryAttached.SaveChanges();

                    _current.PermissionsAttached = null;
                }

                permissionReceives = permissionReceives.Where(w => !permissionCurrents.Contains(w)).ToList();
                if (permissionReceives.Any())
                    _current.PermissionsAttached = permissionReceives.Distinct().ToList().ConvertAll(c => new WebSiteGroupPermissionAttached()
                    {
                        name = c
                    });
                #endregion

                // atualizar
                _repository.Update(_current);
                await _repository.SaveChanges();
            }
        }
        public async Task Delete(WebSiteGroupPermission entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteGroupPermission> FindById(long id)
        {
            return await _repository.Query
                                    .Include(i => i.PermissionsAttached)
                                    .Select(s => new WebSiteGroupPermission()
                                    {
                                        name = s.name,
                                        id = s.id,
                                        PermissionsAttached = s.PermissionsAttached.Select(x => new WebSiteGroupPermissionAttached()
                                        {
                                            name = x.name,
                                            id = x.id
                                        })
                                    }).FirstOrDefaultAsync(f => f.id == id);
        }

        public List<WebSiteGroupPermission> All()
        {
            string key = "cache_group_permission";

            var groupPermissions = _cache.Get<List<WebSiteGroupPermission>>(key);

            if (groupPermissions.IsEmpty())
            {
                groupPermissions = _repository.Query
                        .Include(i => i.PermissionsAttached)
                        .Select(s => new WebSiteGroupPermission()
                        {
                            PermissionsAttached = s.PermissionsAttached.Select(s => new WebSiteGroupPermissionAttached() { name = s.name }),
                            name = s.name,
                            id = s.id
                        }).ToList();

                // salvar cache 5 minutos
                _cache.Set(groupPermissions, key, seconds: 60 * 5);
            }

            return groupPermissions;
        }
    }
}
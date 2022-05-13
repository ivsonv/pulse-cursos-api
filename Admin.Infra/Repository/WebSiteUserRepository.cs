using Admin.Domain.Interface.Entities;
using Admin.Infra.Repository.Base;
using Admin.Domain.Entities;
using Admin.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Admin.Domain.Helpers;

namespace Admin.Infra.Repository
{
    public class WebSiteUserRepository : IWebSiteUserRepository
    {
        private readonly BaseRepository<WebSiteUser> _repository;
        private readonly BaseRepository<WebSiteUserGroupPermission> _repositoryUserGroup;

        public WebSiteUserRepository(
            BaseRepository<WebSiteUserGroupPermission> repositoryUserGroup,
            BaseRepository<WebSiteUser> repository)
        {
            _repositoryUserGroup = repositoryUserGroup;
            _repository = repository;
        }

        public Task<List<WebSiteUser>> Show(Pagination pagination)
        {
            throw new NotImplementedException();
        }
        public async Task Create(WebSiteUser entity)
        {
            entity.email = entity.email.IsCompare().ToLower();
            entity.name = entity.name.IsCompare().ToUpper();

            _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task Update(WebSiteUser entity)
        {
            var _current = await this.FindById(entity.id);
            if (_current != null)
            {
                #region ..: group de acess :..

                var usersReceives = entity.GroupPermissions.Select(s => s.group_permission_id).ToList();
                var usersCurrents = _current.GroupPermissions.Select(s => s.group_permission_id).ToList();
                var usersRemoves = usersCurrents.Where(w => !usersReceives.Contains(w)).ToList();
                if (usersRemoves.Any())
                {
                    var lst = _current.GroupPermissions.Where(w => usersRemoves.Contains(w.group_permission_id)).ToList();
                    _repositoryUserGroup.RemoveRange(lst);
                    await _repositoryUserGroup.SaveChanges();
                }

                usersReceives = usersReceives.Where(w => !usersCurrents.Contains(w)).ToList();
                if (usersReceives.Any())
                    _current.GroupPermissions = usersReceives.ConvertAll(c
                        => new WebSiteUserGroupPermission()
                        {
                            group_permission_id = c
                        });
                #endregion

                _current.name = entity.name.IsCompare().ToUpper();
                _current.email = entity.email.IsCompare();
                _current.active = entity.active;
                _current.id = entity.id;

                _repository.Update(_current);
                await _repository.SaveChanges();
            }
        }
        public async Task Delete(WebSiteUser entity)
        {
            _repository.Remove(entity);
            await _repository.SaveChanges();
        }
        public async Task<WebSiteUser> FindById(long id)
            => await _repository.QueryTrack
                .Include(i => i.GroupPermissions)
                    .ThenInclude(t => t.GroupPermission)
                .FirstOrDefaultAsync(f => f.id == id);
        
        public async Task<WebSiteUser> FindByEmail(string email)
            => await _repository.Query.FirstOrDefaultAsync(s => s.email == email);

        public async Task<WebSiteUser> FindByLogin(string email)
            => await _repository.Query
            .Include(i => i.GroupPermissions)
                .ThenInclude(t => t.GroupPermission)
                .ThenInclude(t => t.PermissionsAttached)
            .FirstOrDefaultAsync(s => s.email == email.ToLower().Trim());

        public async Task<List<WebSiteUser>> Show(Pagination pagination, string search)
            => await _repository.Get(predicate: (p => search.IsEmpty() || 
                                                p.name.ToLower().Contains(search.ToLower()) ||
                                                p.email.ToLower().Contains(search.ToLower())),
                                     pagination: pagination,
                                     order: o => o.id)
                                .Select(s => new WebSiteUser()
                                {
                                    active = s.active,
                                    email = s.email,
                                    name = s.name,
                                    id = s.id,
                                }).AsNoTracking().ToListAsync();
    }
}
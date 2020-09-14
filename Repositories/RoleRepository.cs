using ShopManagement.Generics.Repository;
using ShopManagement.models;
using ShopManagement.Repositories.Interfaces;

namespace ShopManagement.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context) { }
    }
}
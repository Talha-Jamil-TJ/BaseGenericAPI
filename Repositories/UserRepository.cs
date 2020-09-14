using ShopManagement.Generics.Repository;
using ShopManagement.models;
using ShopManagement.Repositories.Interfaces;

namespace ShopManagement.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
using System.Threading.Tasks;
using ShopManagement.models;

namespace ShopManagement.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string userName, string password);

        Task<bool> UserExists(string userName);

        string GetToken(User user);
    }
}
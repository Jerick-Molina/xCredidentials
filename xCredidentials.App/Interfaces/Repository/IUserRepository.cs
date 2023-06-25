using xCredidentials.Domain.Models;

namespace xCredidentials.App.Interfaces.Repository;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User?> GetUserByAuthentication(string email, string password);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByID(string id);
}
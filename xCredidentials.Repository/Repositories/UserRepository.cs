using System.Diagnostics;
using xCredidentials.App.Interfaces.Repository;
using xCredidentials.Domain.Models;

namespace xCredidentials.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataContext _db;

    public UserRepository(ISqlDataContext db)
    {
        _db = db;
    }

    public async Task AddUser(User user) =>
        await _db.SaveData("dbo.spUser_InsertNewUser", new { user.Email, user.Password, user.FirstName, user.LastName });

    public async Task<User?> GetUserByEmail(string email)
    {
        var response = await _db.LoadData<User, dynamic>("dbo.spUser_GetByEmail", new { Email = email });
        return response.FirstOrDefault();
    }

    public async Task<User?> GetUserByID(string id) 
    {
        var response = await _db.LoadData<User, dynamic>("dbo.spUser_GetByID", new { @ID = id });
            return response.FirstOrDefault();
    }

    public async Task<User?> GetUserByAuthentication(string email, string password) {
        var response = await _db.LoadData<User, dynamic>("dbo.spUser_GetByAuthentication", new { Email = email, Password = password });
            return response.FirstOrDefault();
    }
  
    
}

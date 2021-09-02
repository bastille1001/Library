using Library.Services.AuthenticateModels;
using Library.Services.Models;
using System.Collections.Generic;

namespace Library.Services.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User CreateUser(User user);
        User GetById(string id);

    }
}

using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface IUserRepository
{
    void Add(User user);

    UserModel GetUser(Guid id);

    void UpdateUser(User user);

    bool Delete(User user);
}
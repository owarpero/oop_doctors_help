using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IUserService
{
    User Register(string name, string surname, string phone, string email, string password, DateOnly birthdate);

    User? GetUser(Guid id);

    User UpdateUser(Guid id, Dictionary<string, string> data);

    bool DeleteUser(Guid id);
}
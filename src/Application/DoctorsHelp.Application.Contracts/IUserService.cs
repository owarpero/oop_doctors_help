using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IUserService
{
    User Register(string name, string surname, string phone, string email, string password, DateTime birthdate);

    User Login(string phone, string password);

    User GetUser(int id);

    User Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}
namespace DoctorsHelp.Application.Contracts;

using DoctorsHelp.Application.Models;

public interface IUserService
{
    User Register(string name, string surname, string phone, string email, string password, DateTime birthdate);

    User Login(string phone, string password);

    User Get(int id);

    User Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}
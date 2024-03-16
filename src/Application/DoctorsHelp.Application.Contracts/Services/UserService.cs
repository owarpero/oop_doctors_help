using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Register(string name, string surname, string phone, string email, string password, DateOnly? birthdate)
    {
        var user = new User
        {
            Name = name,
            Surname = surname,
            HashedPassword = password,
            Phone = phone,
            Email = email,
            Birthdate = birthdate,
        };
        _userRepository.Add(user);
        return user;
    }

    public User? GetUser(Guid id)
    {
        var userModel = _userRepository.GetUser(id);

        return UserConverter.UserModelToUser(userModel);
    }

    public User UpdateUser(Guid id, Dictionary<string, string> data)
    {
        UserModel userToUpdate = _userRepository.GetUser(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "Name":
                    userToUpdate.Name = entry.Value;
                    break;
                case "Surname":
                    userToUpdate.Surname = entry.Value;
                    break;
                case "Phone":
                    userToUpdate.Phone = entry.Value;
                    break;
                case "Email":
                    userToUpdate.Email = entry.Value;
                    break;
            }
        }

        return UserConverter.UserModelToUser(userToUpdate);
    }

    public bool DeleteUser(Guid id)
    {
        return _userRepository.Delete(new User { Id = id });
    }
}
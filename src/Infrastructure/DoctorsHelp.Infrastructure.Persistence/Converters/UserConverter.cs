using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class UserConverter
{
    public static User UserModelToUser(UserModel? userModel)
    {
        return new User
        {
            Id = userModel?.Id,
            Name = userModel?.Name,
            Surname = userModel?.Surname,
            Phone = userModel?.Phone,
            Email = userModel?.Email,
            HashedPassword = userModel?.HashedPassword,
            Birthdate = userModel?.Birthdate,
            Role = userModel?.Role,
        };
    }
}
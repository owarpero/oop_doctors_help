using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase<User, UserModel>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public UserModel GetUser(Guid id)
    {
        return GetEntry(new User { Id = id }).Entity;
    }

    public void UpdateUser(User user)
    {
        Update(user);
    }

    public bool Delete(User user)
    {
        Remove(user);
        return true;
    }

    protected override DbSet<UserModel> DbSet => ((ApplicationDbContext)Context).Users;

    protected override UserModel MapFrom(User entity)
    {
        return new UserModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Phone = entity.Phone,
            Email = entity.Email,
            HashedPassword = entity.HashedPassword,
            Birthdate = entity.Birthdate,
            Role = entity.Role,
        };
    }

    protected override bool Equal(User entity, UserModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(UserModel model, User entity)
    {
        model.Name = entity.Name;
        model.Surname = entity.Surname;
        model.Phone = entity.Phone;
        model.Email = entity.Email;
        model.HashedPassword = entity.HashedPassword;
        model.Birthdate = entity.Birthdate;
        model.Role = entity.Role;
    }
}
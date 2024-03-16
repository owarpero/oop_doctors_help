using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public class ReviewRepository : RepositoryBase<Review, ReviewModel>
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }

    protected override DbSet<ReviewModel> DbSet => ((ApplicationDbContext)Context).Reviews;

    protected override ReviewModel MapFrom(Review entity)
    {
        return new ReviewModel
        {
            Id = entity.Id,
            AppointmentId = entity.Appointment?.Id ?? 0,
            Grade = entity.Grade,
            Comment = entity.Comment,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }

    protected override bool Equal(Review entity, ReviewModel model)
    {
        return entity.Id == model.Id;
    }

    protected override void UpdateModel(ReviewModel model, Review entity)
    {
        model.AppointmentId = entity.Appointment?.Id ?? 0;
        model.Grade = entity.Grade;
        model.Comment = entity.Comment;
        model.CreatedAt = entity.CreatedAt;
        model.UpdatedAt = entity.UpdatedAt;
    }
}
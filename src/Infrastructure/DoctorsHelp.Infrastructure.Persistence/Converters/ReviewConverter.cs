using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Converters;

public class ReviewConverter
{
    public static Review ReviewModelToReview(ReviewModel? reviewModel)
    {
        return new Review
        {
            Id = reviewModel?.Id,
            Appointment = AppointmentConverter.AppointmentModelToAppointment(reviewModel?.Appointment),
            Grade = reviewModel?.Grade,
            Comment = reviewModel?.Comment,
            CreatedAt = reviewModel?.CreatedAt,
            UpdatedAt = reviewModel?.UpdatedAt,
        };
    }
}
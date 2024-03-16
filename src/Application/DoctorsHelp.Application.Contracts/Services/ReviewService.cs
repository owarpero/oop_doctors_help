using DoctorsHelp.Application.Models;
using DoctorsHelp.Infrastructure.Persistence.Converters;
using DoctorsHelp.Infrastructure.Persistence.Interfaces;
using DoctorsHelp.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Application.Contracts.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public Review Create(Appointment appointment, int grade, string comment)
    {
        var review = new Review
        {
            Appointment = appointment,
            Grade = grade,
            Comment = comment,
        };
        _reviewRepository.Add(review);
        return review;
    }

    public Review? GetReview(int reviewId)
    {
        var reviewModel = _reviewRepository.GetReview(reviewId);

        return ReviewConverter.ReviewModelToReview(reviewModel);
    }

    public Review Update(int id, Dictionary<string, string> data)
    {
        ReviewModel reviewToUpdate = _reviewRepository.GetReview(id);

        foreach (var entry in data)
        {
            switch (entry.Key)
            {
                case "AppointmentId":
                    int appointmentId;
                    if (int.TryParse(entry.Value, out appointmentId))
                        reviewToUpdate.AppointmentId = appointmentId;
                    break;
                case "Rating":
                    int grade;
                    if (int.TryParse(entry.Value, out grade))
                        reviewToUpdate.Grade = grade;
                    break;
                case "Comment":
                    reviewToUpdate.Comment = entry.Value;
                    break;
            }
        }

        return ReviewConverter.ReviewModelToReview(reviewToUpdate);
    }

    public bool Delete(int id)
    {
        return _reviewRepository.Delete(new Review { Id = id });
    }
}
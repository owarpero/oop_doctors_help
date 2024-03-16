using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface IReviewRepository
{
    void Add(Review review);

    ReviewModel GetReview(int id);

    void UpdateReview(Review review);

    bool Delete(Review review);
}
using DoctorsHelp.Application.Models;

namespace DoctorsHelp.Application.Contracts;

public interface IReviewService
{
    Review Create(Appointment appointment, int grade, string comment);

    Review? GetReview(int reviewId);

    Review Update(int id, Dictionary<string, string> data);

    bool Delete(int id);
}
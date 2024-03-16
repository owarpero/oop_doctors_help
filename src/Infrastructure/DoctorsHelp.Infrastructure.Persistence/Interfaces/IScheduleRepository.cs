using DoctorsHelp.Application.Models;
using Infrastructure.Persistence.Models;

namespace DoctorsHelp.Infrastructure.Persistence.Interfaces;

public interface IScheduleRepository
{
    void Add(Schedule schedule);

    ScheduleModel GetSchedule(int id);

    void Update(Schedule schedule);

    bool Delete(Schedule schedule);
}
using System;

namespace ClassSchedule.Models
{
    public interface IClassScheduleUnitOfWork : IDisposable
    {
        IRepository<Class> Classes { get; }
        IRepository<Day> Days { get; }
        IRepository<Teacher> Teachers { get; }
        void Save();
    }
}

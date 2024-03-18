using Microsoft.EntityFrameworkCore;

namespace ClassSchedule.Models
{
    public class ClassScheduleUnitOfWork : IClassScheduleUnitOfWork
    {
        private readonly ClassScheduleContext _context;

        public ClassScheduleUnitOfWork(ClassScheduleContext context)
        {
            _context = context;
            Classes = new Repository<Class>(_context);
            Days = new Repository<Day>(_context);
            Teachers = new Repository<Teacher>(_context);
        }

        public IRepository<Class> Classes { get; }
        public IRepository<Day> Days { get; }
        public IRepository<Teacher> Teachers { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

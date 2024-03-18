using Microsoft.AspNetCore.Mvc;
using ClassSchedule.Models;

namespace ClassSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassScheduleUnitOfWork _unitOfWork;

        public HomeController(IClassScheduleUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index(int id)
        {
            var dayOptions = new QueryOptions<Day> { OrderBy = d => d.DayId };
            var classOptions = new QueryOptions<Class> { Includes = "Teacher, Day" };

            if (id == 0)
            {
                classOptions.OrderBy = c => c.DayId;
            }
            else
            {
                classOptions.Where = c => c.DayId == id;
                classOptions.OrderBy = c => c.MilitaryTime;
            }

            ViewBag.Days = _unitOfWork.Days.List(dayOptions);
            return View(_unitOfWork.Classes.List(classOptions));
        }
    }
}

using CreatedMeetRepository.Model;
using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;

namespace CreaterMeetService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LogsController : GenericController<LOGS>
    {
        private readonly MeetDbContext _context;
        public LogsController(IGenericRepository<LOGS> genericRepository, MeetDbContext context) : base(genericRepository)
        {
            _context = context;
        }



    }
}

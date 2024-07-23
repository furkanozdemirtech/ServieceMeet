using CreatedMeetRepository.Model;
using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;

namespace CreaterMeetService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantsController : GenericController<PARTICIPANTS>
    {
        private readonly MeetDbContext _context;
        public ParticipantsController(IGenericRepository<PARTICIPANTS> genericRepository, MeetDbContext context) : base(genericRepository)
        {
            _context = context;
        }
    }
}

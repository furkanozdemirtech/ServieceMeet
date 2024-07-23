using CreatedMeetRepository.Model;
using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;

namespace CreaterMeetService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolsController : GenericController<ROLES>
    {
        private readonly MeetDbContext _context;
        public RolsController(IGenericRepository<ROLES> genericRepository, MeetDbContext context) : base(genericRepository)
        {
            _context = context;
        }

    }
}

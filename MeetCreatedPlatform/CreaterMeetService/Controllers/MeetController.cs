using CreatedMeetRepository.Model;
using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreaterMeetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetController : GenericController<MEET>
    {
        private readonly MeetDbContext _context;
        public MeetController(IGenericRepository<MEET> genericRepository, MeetDbContext context) : base(genericRepository)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MEET>>> GetAllMeets()
        {
            int count = _context.MEETs.Count();
            return await _context.MEETs.ToListAsync();
        }
        [HttpPost("MeetPost")]
        public async Task<ActionResult<MEET>> Post(MEET entity)
        {

            _context.SaveChanges();
            var createdEntity = await _context.AddAsync(entity);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = GetEntityId(entity) }, createdEntity);
        }
        private int GetEntityId(MEET entity)
        {
            var propertyInfo = entity.GetType().GetProperty("ID");
            return (int)(propertyInfo?.GetValue(entity) ?? 0);
        }
    }
}

using CreatedMeetRepository.Model;
using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreaterMeetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : GenericController<USER>
    {
        private readonly MeetDbContext _context;
        public UserController(IGenericRepository<USER> genericRepository, MeetDbContext context) : base(genericRepository)
        {
            _context = context;
        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<USER>>> GetAllAdres()
        {
            int count = _context.USERs.Count();
            return await _context.USERs.ToListAsync();
        }
        [HttpGet("UserControlIdentity")]
        public async Task<ActionResult<IEnumerable<USER>>> UserControlIdentity(string USERNAME, string PASSWORD)
        {
            //Bu kısımda güncelle işlemi yapılcak 
            var user = await _context.USERs
      .FirstOrDefaultAsync(x => x.USERNAME == USERNAME && x.PASSWORD == PASSWORD);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }

        }
    }
}

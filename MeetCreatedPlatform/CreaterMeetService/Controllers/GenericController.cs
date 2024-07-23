using CreatedMeetRepository.RestGenericInterface;
using Microsoft.AspNetCore.Mvc;

namespace CreaterMeetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericController(IGenericRepository<T> genericRepository)
        {
            this._repository = genericRepository;
        }
        [HttpGet("Load")]
        public async Task<ActionResult<IEnumerable<T>>> Load()
        {
            var enties = await _repository.GetAllAsync();
            return Ok(enties);
        }
        [HttpPost("GetItem")]
        public async Task<ActionResult<T>> GetItem(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return Ok(item);
        }
        [HttpPost("UpdateItem")]
        public async Task<ActionResult<T>> UpdateItem(T item)
        {
            var results = _repository.UpdateAsync(item);
            return Ok(item);
        }
        [HttpPost("DeleteItem")]
        public async Task<bool> DeleteItem(int id)
        {
            var results = await _repository.DeleteAsync(id);
            return true;

        }
        [HttpPost("PostItem")]
        public async Task<ActionResult<T>> PostItem(T item)
        {
            var result = await _repository.AddAsync(item);
            return Ok(result);
        }
    }
}

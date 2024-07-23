namespace CreatedMeetRepository.RestGenericInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T item);
        Task<(bool IsSuccess, T Item)> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}

namespace WebShop.Infrastucture.Interfaces
{
    public interface IRepository<TEntity> where TEntity : new()
    {
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
namespace Produts.api.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetByID(Guid Id);
        T Update(T entity);
        Task<bool> Remove(Guid id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetAll(int tamanho, int pagina);
    }
}

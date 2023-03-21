using Microsoft.EntityFrameworkCore;

namespace Produts.api.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected ProductsContext Context;
        internal DbSet<T> db;
        public BaseRepository(ProductsContext context)
        {
            Context=context;
            this.db= context.Set<T>();
        }
        public virtual async Task<T> GetByID(Guid Id)
        {
            var item = await db.FindAsync(Id);

            return item;
        }

        public virtual async Task<T> Add(T entity)
        {
            await db.AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }


        public virtual async Task<bool> Remove(Guid id)
        {
            try
            {
                var item = await GetByID(id);
                if (item != null) db.Remove(item);
                return true;
            }
            catch (Exception a)
            {
                return false;
            }

        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public virtual IEnumerable<T> GetAll(int tamanho, int pagina)
        {
            var param = "Nome";
            var propertyInfo = typeof(T).GetProperty(param);
            var orderbyNome = db.ToList().Skip(pagina).Take(tamanho).OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            return orderbyNome;
        }
    }
}

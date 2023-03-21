using Produts.api.Models;

namespace Produts.api.Data
{
    public class ProdutosRepository: BaseRepository<Product>, IProdutosRepository
    {
        public ProdutosRepository(ProductsContext context) : base(context)
        {

        }
    }
}
